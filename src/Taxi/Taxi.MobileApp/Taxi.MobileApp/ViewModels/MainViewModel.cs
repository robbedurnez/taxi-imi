using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Plugin.Connectivity;
using Taxi.Domain.DTO;
using Taxi.Domain.Constants;
using Taxi.MobileApp.Contracts;
using Taxi.MobileApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace Taxi.MobileApp.ViewModels
 {
     public class MainViewModel : FreshBasePageModel
     {
         #region Properties

         private readonly IDriversService _driversService;
         private readonly HubConnection _hub;

         private ObservableCollection<CustomPin> availableDriversPins;
         private Position customerPosition;
         private bool deviceConnected;

         public ObservableCollection<CustomPin> AvailableDriversPins
         {
             get => availableDriversPins;
             set
             {
                 availableDriversPins = value;
                 RaisePropertyChanged();
             }
         }
         public Position CustomerPosition
         {
             get => customerPosition;
             set
             {
                 customerPosition = value;
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

         #endregion

         #region Commands

         public ICommand SettingsCommand => new FreshAwaitCommand(async tcs =>
         {
             await CoreMethods.PushPageModel<SettingsViewModel>();
             tcs.SetResult(true);
         });

         public ICommand MarkerClickedCommand => new FreshAwaitCommand(
             async (pin, tcs) =>
             {
                 var customPin = (CustomPin) pin;
                 var driver = await _driversService.GetById(customPin.DriverId);

                 if (driver == null)
                 {
                     await CoreMethods.DisplayAlert("Error", "Driver not available", "Ok");
                 }
                 else
                 {
                     await CoreMethods.PushPageModel<OrderViewModel>(customPin.DriverId);
                 }

                 tcs.SetResult(true);
             });

         #endregion

         public MainViewModel(IDriversService driversService)
         {
             _driversService = driversService;
             _hub = new HubConnectionBuilder()
                 .WithUrl(Connection.SignalRHome)
                 .WithAutomaticReconnect()
                 .ConfigureLogging(logging =>
                 {
                     logging.AddDebug();
                     logging.SetMinimumLevel(LogLevel.Debug);
                 })
                 .Build();

             _hub.On<DriverInRangeDto>(SignalRMessages.GetDriverLocation, dto =>
             {
                 MainThread.BeginInvokeOnMainThread(() =>
                 {
                     var driverLocation = new Location(dto.Latitude, dto.Longitude);
                     var userLocation = new Location(CustomerPosition.Latitude, CustomerPosition.Longitude);

                     if (!(Location.CalculateDistance(driverLocation, userLocation, DistanceUnits.Kilometers) < ApiDriver.Default))
                         return;

                     var pin = new CustomPin()
                     {
                         DriverId = dto.DriverId,
                         Label = dto.IsAvailable ? "Available" : "Unavailable",
                         Position = new Position(dto.Latitude, dto.Longitude)
                     };

                     AvailableDriversPins.Add(pin);
                 });
             });

             _hub.On<DriverInRangeDto>(SignalRMessages.RemoveDriverLocation, dto =>
             {
                 MainThread.BeginInvokeOnMainThread(() =>
                 {
                     var driverLocation = new Location(dto.Latitude, dto.Longitude);
                     var userLocation = new Location(CustomerPosition.Latitude, CustomerPosition.Longitude);

                     if (!(Location.CalculateDistance(driverLocation, userLocation, DistanceUnits.Kilometers) < 5))
                         return;

                     var pin = AvailableDriversPins.SingleOrDefault(p => p.DriverId == dto.DriverId);

                     AvailableDriversPins.Remove(pin);
                 });
             });

             _hub.On<DriverInRangeDto>(SignalRMessages.UpdateDriverLocation, dto =>
             {
                 MainThread.BeginInvokeOnMainThread(() =>
                 {
                     var driverLocation = new Location(dto.Latitude, dto.Longitude);
                     var userLocation = new Location(CustomerPosition.Latitude, CustomerPosition.Longitude);

                     if (!(Location.CalculateDistance(driverLocation, userLocation, DistanceUnits.Kilometers) < 5))
                         return;

                     var pin = AvailableDriversPins.SingleOrDefault(p => p.DriverId == dto.DriverId);

                     if (pin == null)
                     {
                         return;
                     }

                     var newPin = new CustomPin()
                     {
                         DriverId = pin.DriverId,
                         Label = dto.IsAvailable ? "Available" : "Unavailable",
                         Position = new Position(dto.Latitude, dto.Longitude)
                     };

                     AvailableDriversPins.Remove(pin);
                     AvailableDriversPins.Add(newPin);
                 });
             });
         }

         public override async void Init(object initData)
         {
             base.Init(initData);

             await SetCustomerPosition();
             await SetDrivers();
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

             CheckWifiOnStart();
             CheckWifiContinuously();
         }

         #region Methods

         private async Task SetCustomerPosition()
         {
             try
             {
                 var request = new GeolocationRequest(GeolocationAccuracy.Best);
                 var location = await Geolocation.GetLocationAsync(request);

                 if (location != null)
                 {
                     CustomerPosition = new Position(location.Latitude, location.Longitude);
                 }
                 else
                 {
                     await CoreMethods.DisplayAlert("Error", "Location is null", "Ok");
                 }
             }
             catch (FeatureNotSupportedException)
             {
                 await CoreMethods.DisplayAlert("Error", "Geolocation is not supported on your device", "Ok");
             }
             catch (FeatureNotEnabledException)
             {
                 await CoreMethods.DisplayAlert("Error", "Geolocation is not enabled on your device", "Ok");
             }
             catch (PermissionException)
             {
                 await CoreMethods.DisplayAlert("Error", "You have no permission to use this function", "Ok");
             }
             catch (Exception)
             {
                 await CoreMethods.DisplayAlert("Error", "Location could not be found", "Ok");
             }
         }

         private async Task SetDrivers()
         {
             var drivers = await _driversService.GetInRange(CustomerPosition.Latitude, CustomerPosition.Longitude, ApiDriver.Default);

             if (drivers == null)
             {
                 availableDriversPins = new ObservableCollection<CustomPin>();
                 return;
             }

             AvailableDriversPins = new ObservableCollection<CustomPin>(drivers.Select(d => new CustomPin()
             {
                 DriverId = d.Id,
                 Label = d.IsAvailable ? "Available" : "Unavailable",
                 Position = new Position(d.Latitude, d.Longitude)
             }));
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
                     await CoreMethods.PushPageModel<NoConnectionViewModel>("No internet connection. Please connect to a network and reopen the app.");
                 }
             };
         }

         #endregion
     }
 }