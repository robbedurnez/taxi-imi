using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Taxi.MobileApp.Models
{
    public class CustomPin : Pin
    {
        public static readonly BindableProperty DriverIdProperty = 
            BindableProperty.Create(nameof (DriverId), typeof (string), typeof (CustomPin));

        public string DriverId
        {
            get => (string) GetValue(DriverIdProperty);
            set => SetValue(DriverIdProperty, value);
        }
    }
}