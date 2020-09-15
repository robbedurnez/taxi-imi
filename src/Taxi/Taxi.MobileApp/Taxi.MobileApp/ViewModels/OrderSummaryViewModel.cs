using System;
using System.Globalization;
using System.Net.Http;
using System.Windows.Input;
using FreshMvvm;
using Microsoft.AspNetCore.SignalR.Client;
using Taxi.Domain.Constants;
using Taxi.MobileApp.Contracts;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.ViewModels
{
    public class OrderSummaryViewModel : FreshBasePageModel
    {
        #region Properties

        private readonly IOrdersService _ordersService;
        private readonly IAddressesService _addressesService;
        private readonly HubConnection _hub;

        private Order _currentOrder;
        
        private string fromAddress;
        private string toAddress;
        private string totalPrice;

        public string FromAddress
        {
            get => fromAddress;
            set
            {
                fromAddress = value;
                RaisePropertyChanged();
            }
        }
        public string ToAddress
        {
            get => toAddress;
            set
            {
                toAddress = value;
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

        #endregion

        public OrderSummaryViewModel(IOrdersService ordersService, IAddressesService addressesService)
        {
            _ordersService = ordersService;
            _addressesService = addressesService;
            _hub = new HubConnectionBuilder()
                .WithUrl(Connection.SignalRHome)
                .WithAutomaticReconnect()
                .Build();
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

            var fromAddr = await _addressesService.GetAddress(_currentOrder.FromId);
            var toAddr = await _addressesService.GetAddress(_currentOrder.ToId);
            var price = Math.Round(_currentOrder.TotalPrice, 2);

            FromAddress = fromAddr.FullAddress;
            ToAddress = toAddr.FullAddress;
            TotalPrice = price.ToString("C", CultureInfo.GetCultureInfo("nl-BE"));
        }

        #region Commands

        public ICommand PlaceOrderCommand => new FreshAwaitCommand(async tcs =>
        {
            var result = await _ordersService.PlaceOrder(_currentOrder);

            if (result != null)
            {
                await CoreMethods.PushPageModel<OrderPlacedViewModel>(_currentOrder);
            }
            else
            {
                await CoreMethods.DisplayAlert("", "Something went wrong", "Ok");
            }

            tcs.SetResult(true);
        });

        #endregion
    }
}