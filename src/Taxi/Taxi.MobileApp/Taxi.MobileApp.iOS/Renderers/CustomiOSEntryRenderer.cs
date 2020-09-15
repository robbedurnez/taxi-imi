using CoreGraphics;
using Taxi.MobileApp.Controls;
using Taxi.MobileApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomiOSEntryRenderer))]
namespace Taxi.MobileApp.iOS.Renderers
{
    public class CustomiOSEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var view = (CustomEntry) e.NewElement;

            if (view != null)
            {
                Control.Layer.CornerRadius = view.CornerRadius;
                Control.BackgroundColor = view.NewBackgroundColor.ToUIColor();
                Control.Layer.BorderWidth = view.BorderWidth;
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                Control.LeftView = new UIKit.UIView(new CGRect(0, 0, 10, 0));
                Control.LeftViewMode = UIKit.UITextFieldViewMode.Always;
            }
        }

        protected override void Dispose(bool disposing)
        {
            SetElement(null);
        }
    }
}