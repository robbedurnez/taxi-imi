using System.Windows.Input;
using FreshMvvm;

namespace Taxi.MobileApp.ViewModels
{
    public class NoConnectionViewModel : FreshBasePageModel
    {
        #region Properties

        private string message;

        public string Message
        {
            get => message;
            set
            {
                message = value;
            }
        }

        #endregion

        #region Commands

        public ICommand ReturnCommand => new FreshAwaitCommand(async tcs =>
        {
            await CoreMethods.PopPageModel();
            tcs.SetResult(true);
        });

        #endregion

        public override void Init(object initData)
        {
            base.Init(initData);

            Message = (string) initData;
        }
    }
}