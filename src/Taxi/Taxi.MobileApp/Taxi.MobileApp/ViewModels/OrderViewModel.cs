using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Microsoft.AspNetCore.SignalR.Client;
using Taxi.Domain.Constants;
using Taxi.Domain.Models;
using Taxi.MobileApp.Contracts;
using Taxi.MobileApp.Validators;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Address = Taxi.MobileApp.Models.Address;
using Driver = Taxi.MobileApp.Models.Driver;
using Order = Taxi.MobileApp.Models.Order;

namespace Taxi.MobileApp.ViewModels
{
    public class OrderViewModel : FreshBasePageModel
    {
         #region Properties

        private readonly IDriversService _driversService;
        private readonly IAddressesService _addressesService;
        private readonly ICompaniesService _companiesService;
        private readonly IUsersService _usersService;
        private readonly HubConnection _hub;
        private readonly OrderValidator _validator;
        private Order _currentOrder;

        private bool isBusy;
        private Driver driver;
        private Address fromAddress;
        private Address toAddress;
        private string companyName;
        private string isAvailable;
        private Color isAvailableColor;
        private bool detailsVisible;
        private string startPrice;
        private ObservableCollection<Address> addresses;
        private string pricePerKm;
        private string fromPickerErrorText;
        private bool fromPickerErrorVisible;
        private string toPickerErrorText;
        private bool toPickerErrorVisible;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                RaisePropertyChanged();
            }
        }
        public Driver Driver
        {
            get => driver;
            set
            {
                driver = value;
                RaisePropertyChanged();
            }
        }
        public Address FromAddress
        {
            get => fromAddress;
            set
            {
                fromAddress = value;
                RaisePropertyChanged();
            }
        }
        public Address ToAddress
        {
            get => toAddress;
            set
            {
                toAddress = value;
                RaisePropertyChanged();
            }
        }
        public string CompanyName
        {
            get => companyName;
            set
            {
                companyName = value;
                RaisePropertyChanged();
            }
        }
        public string IsAvailable
        {
            get => isAvailable;
            set
            {
                isAvailable = value;
                RaisePropertyChanged();
            }
        }
        public Color IsAvailableColor
        {
            get => isAvailableColor;
            set
            {
                isAvailableColor = value;
                RaisePropertyChanged();
            }
        }
        public bool DetailsVisible
        {
            get => detailsVisible;
            set
            {
                detailsVisible = value;
                RaisePropertyChanged();
            }
        }
        public string StartPrice
        {
            get => startPrice;
            set
            {
                startPrice = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<Address> Addresses
        {
            get => addresses;
            set
            {
                addresses = value;
                RaisePropertyChanged();
            }
        }
        public string PricePerKm
        {
            get => pricePerKm;
            set
            {
                pricePerKm = value;
                RaisePropertyChanged();
            }
        }
        public string FromPickerErrorText
        {
            get => fromPickerErrorText;
            set
            {
                fromPickerErrorText = value;
                RaisePropertyChanged();
            }
        }
        public bool FromPickerErrorVisible
        {
            get => fromPickerErrorVisible;
            set
            {
                fromPickerErrorVisible = value;
                RaisePropertyChanged();
            }
        }
        public string ToPickerErrorText
        {
            get => toPickerErrorText;
            set
            {
                toPickerErrorText = value;
                RaisePropertyChanged();
            }
        }
        public bool ToPickerErrorVisible
        {
            get => toPickerErrorVisible;
            set
            {
                toPickerErrorVisible = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand OrderSummaryCommand => new FreshAwaitCommand(async (tcs) =>
        {
            IsBusy = true;

            var userId = (await _usersService.LoadUserAsync()).Id;

            var order = new Order()
            {
                FromId = FromAddress?.Id,
                ToId = ToAddress?.Id
            };

            if (await Validate(order))
            {
                var fromLocation = new Location(FromAddress.Latitude, FromAddress.Longitude);
                var toLocation = new Location(ToAddress.Latitude, ToAddress.Longitude);

                _currentOrder = new Order()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userId,
                    DriverId = Driver.Id,
                    FromId = FromAddress.Id,
                    ToId = ToAddress.Id,
                    Date = DateTime.Now,
                    State = OrderState.Requested
                };

                var distance = Location.CalculateDistance(fromLocation, toLocation, DistanceUnits.Kilometers);
                var company = await _companiesService.Get(Driver.CompanyId);

                _currentOrder.TotalPrice = distance * company.PricePerKm + company.StartPrice;

                await CoreMethods.PushPageModel<OrderSummaryViewModel>(_currentOrder);
            }

            IsBusy = false;
            tcs.SetResult(true);
        });

        public ICommand NewAddressCommand => new FreshAwaitCommand(async tcs =>
        {
            await CoreMethods.PushPageModel<AddressViewModel>(null);
            tcs.SetResult(true);
        });

        #endregion

        public OrderViewModel(IDriversService driversService,
            IAddressesService addressesService,
            IUsersService usersService,
            ICompaniesService companiesService)
        {
            _driversService = driversService;
            _companiesService = companiesService;
            _addressesService = addressesService;
            _usersService = usersService;
            _validator = new OrderValidator();
            _hub = new HubConnectionBuilder()
                .WithUrl(Connection.SignalRHome)
                .WithAutomaticReconnect()
                .Build();
        }

        public override async void Init(object initData)
        {
            base.Init(initData);

            Driver = await _driversService.GetById((string) initData);
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
                    await CoreMethods.PushPageModel<NoConnectionViewModel>(
                        "Could not connect to server.");
                    return;
                }
            }

            await SetDetails();
        }

        #region Methods

        private async Task<bool> Validate(Order order)
        {
            FromPickerErrorText = "";
            ToPickerErrorText = "";

            var validationResult = await _validator.ValidateAsync(order);

            if (validationResult.IsValid)
                return true;

            validationResult.Errors.ForEach(e =>
            {
                switch (e.PropertyName)
                {
                    case nameof(order.FromId):
                        FromPickerErrorText = e.ErrorMessage;
                        FromPickerErrorVisible = true;
                        break;
                    case nameof(order.ToId):
                        ToPickerErrorText = e.ErrorMessage;
                        ToPickerErrorVisible = true;
                        break;
                }
            });

            return false;
        }

        private async Task SetAddresses()
        {
            var addressesList = await _addressesService.GetByUserId((await _usersService.LoadUserAsync()).Id);

            Addresses = null;
            Addresses = new ObservableCollection<Address>(addressesList);
        }

        private async Task SetDetails()
        {
            await SetAddresses();
            var company = await _companiesService.Get(Driver.CompanyId);
            IsAvailable = Driver.IsAvailable ? "Available" : "Unavailable";
            IsAvailableColor = Driver.IsAvailable ? Color.LimeGreen : Color.Red;
            DetailsVisible = Driver.IsAvailable;
            CompanyName = company.Name;
            StartPrice = company.StartPrice.ToString("C", CultureInfo.GetCultureInfo("nl-BE"));
            PricePerKm = company.PricePerKm.ToString("C", CultureInfo.GetCultureInfo("nl-BE"));
        }

        #endregion
    }
}