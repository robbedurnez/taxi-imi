using CoreGraphics;
using Taxi.MobileApp.Controls;
using Taxi.MobileApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomiOSPickerRenderer))]

namespace Taxi.MobileApp.iOS.Renderers
{
    public class CustomiOSPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            var view = (CustomPicker) e.NewElement;

            if (view != null)
            {
                Control.Layer.CornerRadius = view.CornerRadius;
                Control.BackgroundColor = view.NewBackgroundColor.ToUIColor();
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