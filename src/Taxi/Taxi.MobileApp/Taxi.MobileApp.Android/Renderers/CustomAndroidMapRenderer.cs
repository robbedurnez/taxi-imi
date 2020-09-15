using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Taxi.MobileApp.Droid.Renderers;
using Taxi.MobileApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;

[assembly: ExportRenderer(typeof(TaxiMap), typeof(CustomAndroidMapRenderer))]
namespace Taxi.MobileApp.Droid.Renderers
{
    public class CustomAndroidMapRenderer : MapRenderer
    {
        public CustomAndroidMapRenderer(Context context) : base(context)
        {
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            marker.SetIcon(pin.Label == "Available"
                ? BitmapDescriptorFactory.FromResource(Resource.Drawable.taxi_available)
                : BitmapDescriptorFactory.FromResource(Resource.Drawable.taxi_unavailable));
            return marker;
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            map.MarkerClick += OnPinClicked;
        }

        private void OnPinClicked(object sender, GoogleMap.MarkerClickEventArgs e)
        {
            e.Handled = true;
        }
    }
}