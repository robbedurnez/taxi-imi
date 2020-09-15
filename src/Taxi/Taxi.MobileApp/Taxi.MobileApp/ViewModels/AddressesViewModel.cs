using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;
using FreshMvvm;
using Microsoft.AspNetCore.SignalR.Client;
using Taxi.Domain.Constants;
using Taxi.MobileApp.Models;
using Taxi.MobileApp.Contracts;
using Xamarin.Forms;

namespace Taxi.MobileApp.ViewModels
{
    public class AddressesViewModel : FreshBasePageModel
    {
        #region Properties

        private readonly IUsersService _usersService;
        private readonly IAddressesService _addressesService;
        private readonly HubConnection _hub;
        private User user;
        
        private ObservableCollection<Address> addresses;
        private bool isBusy;
        
        public ObservableCollection<Address> Addresses
        {
            get => addresses;
            set
            {
                addresses = value;
                RaisePropertyChanged();
            }
        }
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }

        #endregion

        #region Commands

        public ICommand NewAddressCommand => new Command(
            async () => { await CoreMethods.PushPageModel<AddressViewModel>(null); }
            );
        
        public ICommand EditAddressCommand => new Command<Address>(
            async (address) => { await CoreMethods.PushPageModel<AddressViewModel>(address); }
        );

        public ICommand DeleteAddressCommand => new Command<Address>(
            async (address) =>
            {
                await _addressesService.DeleteAddress(address.Id);
                RefreshCommand.Execute(null);
            });
        
        public ICommand RefreshCommand => new Command(
            async () =>
            {
                IsBusy = true;

                try
                {
                    var addressList = await _addressesService.GetByUserId(user.Id);
                    Addresses = null;
                    if (addressList != null)
                    {
                        Addresses = new ObservableCollection<Address>(addressList);
                    }
                    else
                    {
                        Addresses = new ObservableCollection<Address>();
                    }
                }
                catch (Exception e)
                {
                    await CoreMethods.DisplayAlert("Error", $"{e.Message}", "Ok");
                }
                finally
                {
                    IsBusy = false;
                }
            });

        #endregion

        public AddressesViewModel(IUsersService usersService,
            IAddressesService addressesService)
        {
            _usersService = usersService;
            _addressesService = addressesService;
            _hub = new HubConnectionBuilder()
                .WithUrl(Connection.SignalRHome)
                .WithAutomaticReconnect()
                .Build();
            
            MessagingCenter.Subscribe(this, MessagingCenterMessages.AddressSaved, (AddressViewModel sender, Address savedAddress) =>
            {
                RefreshCommand.Execute(null);
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
            
            user = await _usersService.LoadUserAsync();
            RefreshCommand.Execute(null);
        }
    }
}