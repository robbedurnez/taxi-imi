using System.Windows.Input;
using FreshMvvm;
using Taxi.MobileApp.Contracts;

namespace Taxi.MobileApp.ViewModels
{
    public class SettingsViewModel : FreshBasePageModel
    {
        #region Properties

        private readonly IUsersService _usersService;

        #endregion

        #region Commands

        public ICommand AddressesCommand => new FreshAwaitCommand(
            async (tcs) =>
            {
                await CoreMethods.PushPageModel<AddressesViewModel>();
                tcs.SetResult(true);
            }
        );
        
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

        public SettingsViewModel(IUsersService usersService)
        {
            _usersService = usersService;
        }
    }
}