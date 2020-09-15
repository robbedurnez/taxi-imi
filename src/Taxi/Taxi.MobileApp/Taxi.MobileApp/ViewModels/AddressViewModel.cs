using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Microsoft.AspNetCore.SignalR.Client;
using Taxi.Domain.Constants;
using Taxi.MobileApp.Contracts;
using Taxi.MobileApp.Models;
using Taxi.MobileApp.Validators;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Taxi.MobileApp.ViewModels
{
    public class AddressViewModel : FreshBasePageModel
    {
        #region Properties

        private readonly IAddressesService _addressesService;
        private readonly IUsersService _usersService;
        private readonly AddressValidator _addressValidator;
        private readonly HubConnection _hub;

        private Address _currentAddress;
        private bool _isNew;
        
        private string pageTitle;
        private bool isBusy;
        private string addressLine1;
        private string addressLine2;
        private string postalCode;
        private string city;
        private string addressLine1Error;
        private string addressLine2Error;
        private string postalCodeError;
        private string cityError;
        
        public string PageTitle
        {
            get { return pageTitle; }
            set
            {
                pageTitle = value;
                RaisePropertyChanged();
            }
        }
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged();
            }
        }
        public string AddressLine1
        {
            get => addressLine1;
            set
            {
                addressLine1 = value;
                RaisePropertyChanged();
            }
        }
        public string AddressLine2
        {
            get => addressLine2;
            set
            {
                addressLine2 = value;
                RaisePropertyChanged();
            }
        }
        public string PostalCode
        {
            get => postalCode;
            set
            {
                postalCode = value;
                RaisePropertyChanged();
            }
        }
        public string City
        {
            get => city;
            set
            {
                city = value;
                RaisePropertyChanged();
            }
        }
        public string AddressLine1Error
        {
            get => addressLine1Error;
            set
            {
                addressLine1Error = value;
                RaisePropertyChanged();
            }
        }
        public string AddressLine2Error
        {
            get => addressLine2Error;
            set
            {
                addressLine2Error = value;
                RaisePropertyChanged();
            }
        }
        public string PostalCodeError
        {
            get => postalCodeError;
            set
            {
                postalCodeError = value;
                RaisePropertyChanged();
            }
        }
        public string CityError
        {
            get => cityError;
            set
            {
                cityError = value;
                RaisePropertyChanged();
            }
        }
        
        #endregion
        
        #region Commands

        public ICommand SaveAddressCommand => new Command(
            async () =>
            {
                IsBusy = true;

                try
                {
                    await SaveAddressState();
                    
                    if (Validate(_currentAddress))
                    {
                        if (_isNew)
                        {
                            await _addressesService.Add(_currentAddress);
                        }
                        else
                        {
                            await _addressesService.UpdateAddress(_currentAddress);
                        }
                        
                        IsBusy = false;
                        MessagingCenter.Send(this, MessagingCenterMessages.AddressSaved, _currentAddress);
                        await CoreMethods.PopPageModel();
                    }
                    
                    IsBusy = false;
                }
                catch (Exception)
                {
                    await CoreMethods.DisplayAlert("Error", "Error while saving address", "Ok");
                }
                finally
                {
                    IsBusy = false;
                }
            });
        
        #endregion

        public AddressViewModel(IAddressesService addressesService, IUsersService usersService, Address address)
        {
            _addressesService = addressesService;
            _usersService = usersService;
            _addressValidator = new AddressValidator();
            _hub = new HubConnectionBuilder()
                .WithUrl(Connection.SignalRHome)
                .WithAutomaticReconnect()
                .Build();
        }

        public override async void Init(object initData)
        {
            base.Init(initData);

            _currentAddress = initData as Address;

            await RefreshAddress();
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
        }

        #region Methods

        private void LoadAddressState()
        {
            AddressLine1 = _currentAddress.AddressLine1;
            AddressLine2 = _currentAddress.AddressLine2;
            PostalCode = _currentAddress.PostalCode;
            City = _currentAddress.City;
        }

        private async Task SaveAddressState()
        {
            _currentAddress.AddressLine1 = AddressLine1;
            _currentAddress.AddressLine2 = AddressLine2;
            _currentAddress.PostalCode = PostalCode;
            _currentAddress.City = City;
            _currentAddress.UserId = (await _usersService.LoadUserAsync()).Id;
        }

        private async Task RefreshAddress()
        {
            if (_currentAddress != null)
            {
                _isNew = false;
                PageTitle = "Edit address";
                _currentAddress = await _addressesService.GetAddress(_currentAddress.Id);
            }
            else
            {
                _isNew = true;
                PageTitle = "New address";
                _currentAddress = new Address
                {
                    UserId = (await _usersService.LoadUserAsync()).Id,
                    Id = Guid.NewGuid().ToString()
                };
            }
            
            LoadAddressState();
        }

        private bool Validate(Address address)
        {
            AddressLine1Error = "";
            AddressLine2Error = "";
            PostalCodeError = "";
            CityError = "";

            var validationResult = _addressValidator.Validate(address);

            if (validationResult.IsValid)
                return true;
            
            validationResult.Errors.ForEach(e =>
            {
                switch (e.PropertyName)
                {
                    case nameof(address.AddressLine1):
                        AddressLine1Error = e.ErrorMessage;
                        break;
                    case nameof(address.AddressLine2):
                        AddressLine2Error = e.ErrorMessage;
                        break;
                    case nameof(address.PostalCode):
                        PostalCodeError = e.ErrorMessage;
                        break;
                    case nameof(address.City):
                        CityError = e.ErrorMessage;
                        break;
                }
            });
                
            return false;
        }

        #endregion
    }
}