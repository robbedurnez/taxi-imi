using Android.Content;
using Android.Graphics.Drawables;
using Taxi.MobileApp.Controls;
using Taxi.MobileApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomAndroidEntryRenderer))]

namespace Taxi.MobileApp.Droid.Renderers
{
    public class CustomAndroidEntryRenderer : EntryRenderer
    {
        public CustomAndroidEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var view = (CustomEntry) Element;
            
            if (Control != null)
            {
                var gd = new GradientDrawable();
                gd.SetCornerRadius(view.CornerRadius);
                gd.SetColor(view.NewBackgroundColor.ToAndroid());
                gd.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());
                Control.SetBackgroundColor(Color.Transparent);
                Control.SetPadding(20, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
                Control.SetBackground(gd);
            }
        }
    }
}