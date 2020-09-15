using System.Windows.Input;
using FreshMvvm;

namespace Taxi.MobileApp.ViewModels
{
    public class SignInSignUpViewModel : FreshBasePageModel
    {
        #region Commands

        public ICommand SignUpCommand => new FreshAwaitCommand(
            async (tcs) =>
            {
                await CoreMethods.PushPageModel<SignUpViewModel>();
                tcs.SetResult(true);
            }
        );
        
        public ICommand SignInCommand => new FreshAwaitCommand(
            async (tcs) =>
            {
                await CoreMethods.PushPageModel<SignInViewModel>();
                tcs.SetResult(true);
            }
        );

        #endregion
    }
}