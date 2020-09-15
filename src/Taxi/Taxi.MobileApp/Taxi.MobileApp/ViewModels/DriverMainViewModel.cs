using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Plugin.Connectivity;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.SimpleAudioPlayer;
using Taxi.Domain.Constants;
using Taxi.Domain.DTO;
using Taxi.Domain.Models;
using Taxi.MobileApp.Contracts;
using Xamarin.Essentials;
using Xamarin.Forms;
using Driver = Taxi.MobileApp.Models.Driver;
using Order = Taxi.MobileApp.Models.Order;

namespace Taxi.MobileApp.ViewModels
{
    public class DriverMainViewModel : FreshBasePageModel
    {
        #region Properties

        private readonly IUsersService _usersService;
        private readonly IDriversService _driversService;
        private readonly IOrdersService _ordersService;
        private readonly IAddressesService _addressesService;
        private Driver _currentDriver;
        private readonly HubConnection _hub;
        private readonly ISimpleAudioPlayer _simpleAudioPlayer;
        private bool deviceConnected;

        private bool activityToggleVisible;
        private string activeText;
        private string buttonText;
        private Color activeTextColor;
        private bool isActive;
        private bool orderRequested;
        private Order currentOrder;
        private bool orderAccepted;
        private string fullFromAddress;
        private string fullToAddress;
        private bool animationPlaying;
        private string orderTotal;

        public bool ActivityToggleVisible
        {
            get => activityToggleVisible;
            set
            {
                activityToggleVisible = value;
                RaisePropertyChanged();
            }
        }
        public string ActiveText
        {
            get => activeText;
            set
            {
                activeText = value;
                RaisePropertyChanged();
            }
        }
        public string ButtonText
        {
            get => buttonText;
            set
            {
                buttonText = value;
                RaisePropertyChanged();
            }
        }
        public Color ActiveTextColor
        {
            get => activeTextColor;
            set
            {
                activeTextColor = value;
                RaisePropertyChanged();
            }
        }
        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                RaisePropertyChanged();
            }
        }
        public bool OrderRequested
        {
            get => orderRequested;
            set
            {
                orderRequested = value;
                RaisePropertyChanged();
            }
        }
        public Order CurrentOrder
        {
            get => currentOrder;
            set
            {
                currentOrder = value;
                RaisePropertyChanged();
            }
        }
        public bool OrderAccepted
        {
            get => orderAccepted;
            set
            {
                orderAccepted = value;
                RaisePropertyChanged();
            }
        }
        public string FullFromAddress
        {
            get => fullFromAddress;
            set
            {
                fullFromAddress = value;
                RaisePropertyChanged();
            }
        }
        public string FullToAddress
        {
            get => fullToAddress;
            set
            {
                fullToAddress = value;
                RaisePropertyChanged();
            }
        }
        public bool AnimationPlaying
        {
            get => animationPlaying;
            set
            {
                animationPlaying = value;
                RaisePropertyChanged();
            }
        }
        public bool DeviceConnected
        {
            get => deviceConnected;
            set
            {
                deviceConnected = value;
                RaisePropertyChanged();
            }
        }
        public string OrderTotal
        {
            get => orderTotal;
            set
            {
                orderTotal = value;
                RaisePropertyChanged();
            }
        }

        #endregion
        
        #region Commands

        public ICommand ToggleActiveCommand => new FreshAwaitCommand(async (tcs) =>
        {
            var result = await _driversService.ToggleActive(_currentDriver);
            
            if (result == null)
            {
                await CoreMethods.DisplayAlert("Error", "Driver not found", "Ok");
            }
            else
            {
                _currentDriver = result;
                IsActive = _currentDriver.IsActive;
            
                if (IsActive)
                {
                    ActiveText = "You are active";
                    ActiveTextColor = Color.LimeGreen;
                    ButtonText = "Go inactive";
                }
                else
                {
                    ActiveText = "You are inactive";
                    ActiveTextColor = Color.Red;
                    ButtonText = "Go active";
                }
            }

            tcs.SetResult(true);
        });
        
        public ICommand AcceptOrderCommand => new FreshAwaitCommand(async (order, tcs) =>
        {
            var result = await _ordersService.AcceptOrder(order as Order);

            if (result == null)
            {
                await CoreMethods.DisplayAlert("", "Error accepting order", "Ok");
            }
            else
            {
                OrderRequested = false;
                OrderAccepted = true;
                _currentDriver = await _driversService.ToggleAvailable(_currentDriver);
                AnimationPlaying = true;
            }
            
            tcs.SetResult(true);
        });

        public ICommand RefuseOrderCommand => new FreshAwaitCommand(async (order, tcs) =>
        {
            var result = await _ordersService.RefuseOrder(order as Order);

            if (result == null)
            {
                await CoreMethods.DisplayAlert("", "Error refusing order", "Ok");
            }

            ActivityToggleVisible = true;
            OrderRequested = false;
            tcs.SetResult(true);
        });

        public ICommand OpenFromAddressCommand => new FreshAwaitCommand(async (order, tcs) =>
        {
            var fromAddress = await _addressesService.GetAddress(CurrentOrder.FromId);
            var location = new Location(fromAddress.Latitude, fromAddress.Longitude);

            await Map.OpenAsync(location);
            tcs.SetResult(true);
        });

        public ICommand OpenToAddressCommand => new FreshAwaitCommand(async (order, tcs) =>
        {
            var toAddress = await _addressesService.GetAddress(CurrentOrder.ToId);
            var location = new Location(toAddress.Latitude, toAddress.Longitude);

            await Map.OpenAsync(location);
            tcs.SetResult(true);
        });
        
        public ICommand FinalizeOrderCommand => new FreshAwaitCommand(async (order, tcs) =>
        {
            var result = await _ordersService.FinalizeOrder(order as Order);

            if (result == null)
            {
                await CoreMethods.DisplayAlert("", "Finaling order failed", "Ok");
            }
            else
            {
                var driver = await _driversService.ToggleAvailable(_currentDriver);

                if (driver == null)
                {
                    await CoreMethods.DisplayAlert("", "Error setting availability", "Ok");
                }
                else
                {
                    ActivityToggleVisible = true;
                    OrderAccepted = false;
                    OrderRequested = false;
                }
            }
            
            tcs.SetResult(true);
        });
        
        public ICommand SignOutCommand => new FreshAwaitCommand(
            async (tcs) =>
            {
                var result = await CoreMethods.DisplayAlert("", "Do you really want to sign out?", "Yes", "No");

                if (result)
                {
                    await _usersService.SignOutAsync();
                    await CoreMethods.PushPageModel<StartViewModel>();
                }
                
                tcs.SetResult(true);
            });

        #endregion

        public DriverMainViewModel(IDriversService driversService, IUsersService usersService, IOrdersService ordersService, IAddressesService addressesService)
        {
            _driversService = driversService;
            _usersService = usersService;
            _ordersService = ordersService;
            _addressesService = addressesService;
            _simpleAudioPlayer = CrossSimpleAudioPlayer.Current;
            _hub = new HubConnectionBuilder()
                .WithUrl(Connection.SignalRHome)
                .WithAutomaticReconnect()
                .ConfigureLogging(logging =>
                {
                    logging.AddDebug();
                    logging.SetMinimumLevel(LogLevel.Debug);
                })
                .Build();

            _hub.On<OrderDto>(SignalRMessages.OrderRequested, model =>
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    if (_currentDriver.Id != model.DriverId)
                    {
                        return;
                    }
                    
                    _simpleAudioPlayer.Play();
                
                    var order = App.CreateMapper().Map<Order>(model);
                
                    CurrentOrder = order;
                    
                    var fromAddress = await _addressesService.GetAddress(CurrentOrder.FromId);
                    var toAddress = await _addressesService.GetAddress(CurrentOrder.ToId);
                
                    var price = Math.Round(CurrentOrder.TotalPrice, 2);
                    OrderTotal = price.ToString("C", CultureInfo.GetCultureInfo("nl-BE"));
                    FullFromAddress = fromAddress.FullAddress;
                    FullToAddress = toAddress.FullAddress;
                    OrderRequested = true;
                    ActivityToggleVisible = false;
                    await StopListening();
                });
            });
            
            CheckWifiOnStart();
            CheckWifiContinuously();
            
            MessagingCenter.Subscribe<object>(this, MessagingCenterMessages.AppSleep, sender =>
            {
                if (CurrentOrder != null)
                {
                    if (CurrentOrder.State == OrderState.Requested || CurrentOrder.State == OrderState.Handled)
                    {
                        Application.Current.Properties.TryAdd("orderId", CurrentOrder.Id);
                    }
                }
            });
            
            MessagingCenter.Subscribe<object, string>(this, MessagingCenterMessages.DriverSignOut, async (sender, id) =>
            {
                if (_currentDriver.Id != id)
                {
                    return;
                }
                
                if (_currentDriver.IsActive)
                {
                    await _driversService.ToggleActive(_currentDriver);
                }
            });
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

            _simpleAudioPlayer.Load("horn.mp3");
            
            var user = await _usersService.LoadUserAsync();
            
            _currentDriver = await _driversService.GetById(user.Id);
            
            if (Application.Current.Properties.ContainsKey("orderId"))
            {
                var id = (string) Application.Current.Properties["orderId"];
                var order = await _ordersService.Get(id);

                if (order == null)
                {
                    await CoreMethods.DisplayAlert("", "Error trying to load order state", " Ok");
                    
                    return;
                }
 
                CurrentOrder = order;
                OrderTotal = Math.Round(CurrentOrder.TotalPrice, 2).ToString("C", CultureInfo.GetCultureInfo("nl-BE"));
                FullFromAddress = (await _addressesService.GetAddress(CurrentOrder.FromId)).FullAddress;
                FullToAddress = (await _addressesService.GetAddress(CurrentOrder.ToId)).FullAddress;

                switch (order.State)
                {
                    case OrderState.Requested:
                        OrderRequested = true;
                        break;
                    case OrderState.Handled:
                        OrderAccepted = true;
                        AnimationPlaying = true;
                        break;
                }

                Application.Current.Properties.Remove("orderId");
            }
            else
            {
                CurrentOrder = null;
                IsActive = _currentDriver.IsActive;
                ActivityToggleVisible = true;
                OrderAccepted = false;
                OrderRequested = false;
            
                if (IsActive)
                {
                    ActiveText = "You are active";
                    ActiveTextColor = Color.LimeGreen;
                    ButtonText = "Go inactive";
                }
                else
                {
                    ActiveText = "You are inactive";
                    ActiveTextColor = Color.DarkRed;
                    ButtonText = "Go active";
                }
            }

            await StartListening();
        }

        #region Methods

        private async Task StartListening()
        {
            if (CrossGeolocator.Current.IsListening)
            {
                return;
            }
            
            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 10, true);
            CrossGeolocator.Current.PositionChanged += PositionChanged;
            CrossGeolocator.Current.PositionError += PositionError;
        }
        
        private async void PositionChanged(object sender, PositionEventArgs e)
        {
            var position = e.Position;

            _currentDriver.Latitude = position.Latitude;
            _currentDriver.Longitude = position.Longitude;

            await _driversService.UpdateLocation(_currentDriver);
        }
        
        private void PositionError(object sender, PositionErrorEventArgs e)
        {
            Console.Write(e.Error.ToString());
        } 
        
        private async Task StopListening()
        {
            if(!CrossGeolocator.Current.IsListening)
                return;
	
            await CrossGeolocator.Current.StopListeningAsync();

            CrossGeolocator.Current.PositionChanged -= PositionChanged;
            CrossGeolocator.Current.PositionError -= PositionError;
        }
        
        private void CheckWifiOnStart()
        {
            DeviceConnected = CrossConnectivity.Current.IsConnected;
        }

        private void CheckWifiContinuously()
        {
            CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
            {
                DeviceConnected = args.IsConnected;
                if (!DeviceConnected)
                {
                    await CoreMethods.PushPageModel<NoConnectionViewModel>("Could not connect to server.");
                }
            };
        }

        #endregion
    }
}