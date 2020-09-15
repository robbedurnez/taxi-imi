using Android.Content;
using Android.Graphics.Drawables;
using Taxi.MobileApp.Controls;
using Taxi.MobileApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomAndroidPickerRenderer))]

namespace Taxi.MobileApp.Droid.Renderers
{
    public class CustomAndroidPickerRenderer : PickerRenderer
    {
        public CustomAndroidPickerRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            
            var view = (CustomPicker) Element;
            
            if (Control != null)
            {
                var gd = new GradientDrawable();
                gd.SetCornerRadius(view.CornerRadius);
                gd.SetColor(view.NewBackgroundColor.ToAndroid());
                Control.SetBackgroundColor(Color.Transparent);
                Control.SetPadding(20, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
                Control.SetBackground(gd);
            }
        }
    }
}