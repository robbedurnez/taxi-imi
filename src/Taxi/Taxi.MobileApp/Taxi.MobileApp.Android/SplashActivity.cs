using System.Threading.Tasks;
using Android.App;
using Android.Content;

namespace Taxi.MobileApp.Droid
{
    [Activity(Label = "Taxi!", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() => { StartActivity(new Intent(Application.Context, typeof(MainActivity))); });
            startupWork.Start();
        }

        public override void OnBackPressed() { }
    }
}