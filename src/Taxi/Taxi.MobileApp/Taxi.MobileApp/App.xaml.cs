using System.Collections.Generic;
using System.IO;
using AutoMapper;
using FreshMvvm;
using Newtonsoft.Json;
using Taxi.Domain.Constants;
using Taxi.Domain.Models;
using Taxi.MobileApp.Contracts;
using Taxi.MobileApp.Services.Api;
using Taxi.MobileApp.Services.AutoMapper;
using Taxi.MobileApp.Themes;
using Taxi.MobileApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using User = Taxi.MobileApp.Models.User;

namespace Taxi.MobileApp
{
    public partial class App : Application
    {
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new AddressProfile());
                    cfg.AddProfile(new DriverProfile());
                    cfg.AddProfile(new CompanyProfile());
                    cfg.AddProfile(new OrderProfile());
                    cfg.AddProfile(new UserProfile());
                });

            return mapperConfiguration.CreateMapper();
        }
        
        public App()
        {
            InitializeComponent();
            
            FreshIOC.Container.Register<IUsersService, ApiUsersService>();
            FreshIOC.Container.Register<IAddressesService, ApiAddressesService>();
            FreshIOC.Container.Register<IDriversService, ApiDriversService>();
            FreshIOC.Container.Register<ICompaniesService, ApiCompaniesService>();
            FreshIOC.Container.Register<IOrdersService, ApiOrdersService>();
            
            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<StartViewModel>());
        }

        protected override async void OnStart()
        {
            ApplyTheme();
            var path = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            
            if (File.Exists(path))
            {
                var user = JsonConvert.DeserializeObject<User>(await File.ReadAllTextAsync(path));
                
                MainPage = user.UserType == UserType.Customer
                    ? new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>())
                    : new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<DriverMainViewModel>());
            }
        }

        protected override void OnSleep()
        {
            MessagingCenter.Send<object>(this, MessagingCenterMessages.AppSleep);
        }

        protected override void OnResume()
        {
            
        }

        private static void ApplyTheme()
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                
                if (AppInfo.RequestedTheme == AppTheme.Dark)
                {
                    mergedDictionaries.Add(new DarkTheme());
                }
                else
                {
                    mergedDictionaries.Add(new LightTheme());
                }
            }
        }
    }
}
