using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Windows.Input;
using FreshMvvm;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Taxi.Domain.Constants;
using Taxi.Domain.DTO;
using Taxi.Domain.Models;
using Taxi.MobileApp.Contracts;
using Xamarin.Essentials;
using Xamarin.Forms;
using Order = Taxi.MobileApp.Models.Order;

namespace Taxi.MobileApp.ViewModels
{
    public class OrderPlacedViewModel : FreshBasePageModel
    {
        #region Properties

        private IOrdersService _ordersService;
        private Order _currentOrder;
        private HubConnection _hub;

        private string mainText;
        private string currentAnimation;
        private bool animationLoop;
        private bool orderHandled;
        private string totalPrice;
        private bool orderRefused;
        private bool orderFinalized;

        public string MainText
        {
            get => mainText;
            set
            {
                mainText = value;
                RaisePropertyChanged();
            }
        }
        public string CurrentAnimation
        {
            get => currentAnimation;
            set
            {
                currentAnimation = value;
                RaisePropertyChanged();
            }
        }
        public bool AnimationLoop
        {
            get => animationLoop;
            set
            {
                animationLoop = value;
                RaisePropertyChanged();
            }
        }
        public bool OrderHandled
        {
            get => orderHandled;
            set
            {
                orderHandled = value;
                RaisePropertyChanged();
            }
        }
        public string TotalPrice
        {
            get => totalPrice;
            set
            {
                totalPrice = value;
                RaisePropertyChanged();
            }
        }
        public bool OrderRefused
        {
            get => orderRefused;
            set
            {
                orderRefused = value;
                RaisePropertyChanged();
            }
        }
        public bool OrderFinalized
        {
            get => orderFinalized;
            set
            {
                orderFinalized = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand ReturnToMapCommand => new FreshAwaitCommand(async tcs =>
        {
            await CoreMethods.PushPageModel<MainViewModel>();
            tcs.SetResult(true);
        });

        #endregion

        public OrderPlacedViewModel(IOrdersService ordersService)
        {
            _ordersService = ordersService;
            _hub = new HubConnectionBuilder()
                .WithUrl(Connection.SignalRHome)
                .WithAutomaticReconnect()
                .ConfigureLogging(options =>
                {
                    options.AddDebug();
                    options.SetMinimumLevel(LogLevel.Debug);
                })
                .Build();

            _hub.On<OrderDto>(SignalRMessages.OrderAccepted, dto =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (_currentOrder.Id == dto.Id)
                    {
                        _currentOrder = App.CreateMapper().Map<Order>(dto);
                        MainText = "Order has been accepted. Your driver is on the way!";
                        AnimationLoop = false;
                        CurrentAnimation = "success.json";
                        OrderHandled = true;
                        TotalPrice = Math.Round(_currentOrder.TotalPrice, 2).ToString("C", CultureInfo.GetCultureInfo("nl-BE"));
                    }
                });
            });

            _hub.On<OrderDto>(SignalRMessages.OrderRefused, dto =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (_currentOrder.Id == dto.Id)
                    {
                        _currentOrder = App.CreateMapper().Map<Order>(dto);
                        MainText = "Your order has been refused.";
                        AnimationLoop = false;
                        CurrentAnimation = "error.json";
                        OrderRefused = true;
                        OrderFinalized = true;
                    }
                });
            });

            _hub.On<OrderDto>(SignalRMessages.OrderFinalized, dto =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (_currentOrder.Id == dto.Id)
                    {
                        _currentOrder = App.CreateMapper().Map<Order>(dto);
                        MainText = "Your order has been finalized.";
                        CurrentAnimation = "";
                        OrderFinalized = true;
                        OrderHandled = false;
                    }
                });
            });

            MessagingCenter.Subscribe<object>(this, MessagingCenterMessages.AppSleep, sender =>
            {
                Application.Current.Properties.TryAdd("orderId", _currentOrder.Id);
            });
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            
            _currentOrder = initData as Order;
        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            if (_hub.State == HubConnectionState.Disconnected)
            {
                try
                {
                    await _hub.StartAsync();
                }
                catch (HttpRequestException)
                {
                    await CoreMethods.PushPageModel<NoConnectionViewModel>("Could not connect to server.");
                    return;
                }
            }

            if (Application.Current.Properties.ContainsKey("orderId"))
            {
                var id = (string) Application.Current.Properties["orderId"];
                
                Application.Current.Properties.Remove("orderId");

                var order = await _ordersService.Get(id);

                if (order.Id == _currentOrder.Id)
                {
                    _currentOrder = order;
                    TotalPrice = Math.Round(_currentOrder.TotalPrice, 2).ToString("C", CultureInfo.GetCultureInfo("nl-BE"));

                    switch (_currentOrder.State)
                    {
                        case OrderState.Requested:
                            MainText = "Waiting for driver response...";
                            CurrentAnimation = "loading.json";
                            AnimationLoop = true;
                            OrderHandled = false;
                            OrderFinalized = false;
                            OrderRefused = false;
                            break;
                        case OrderState.Handled:
                            MainText = "Order has been accepted. Your driver is on the way!";
                            AnimationLoop = false;
                            CurrentAnimation = "success.json";
                            OrderHandled = true;
                            OrderFinalized = false;
                            OrderRefused = false;
                            break;
                        case OrderState.Finalized:
                            MainText = "Your order has been finalized.";
                            CurrentAnimation = "";
                            OrderFinalized = true;
                            OrderHandled = false;
                            break;
                        case OrderState.Refused:
                            MainText = "Your order has been refused.";
                            CurrentAnimation = "error.json";
                            AnimationLoop = false;
                            OrderHandled = false;
                            OrderFinalized = true;
                            OrderRefused = true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    return;
                }
            }

            MainText = "Waiting for driver response...";
            CurrentAnimation = "loading.json";
            AnimationLoop = true;
        }
    }
}