using System.Windows.Input;
using FreshMvvm;
using Taxi.Domain.Models;

namespace Taxi.MobileApp.ViewModels
{
    public class StartViewModel : FreshBasePageModel
    {
        #region Commands

        public ICommand UserTypeTappedCommand => new FreshAwaitCommand(
            async (userType, tcs) =>
            {
                if ((UserType) userType == UserType.Customer)
                {
                    await CoreMethods.PushPageModel<SignInSignUpViewModel>();
                }
                else
                {
                    await CoreMethods.PushPageModel<SignInViewModel>();
                }
                
                tcs.SetResult(true);
            }
        );

        #endregion
    }
}