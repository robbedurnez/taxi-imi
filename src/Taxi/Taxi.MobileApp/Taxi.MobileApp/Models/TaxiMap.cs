using Taxi.Domain.Constants;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Taxi.MobileApp.Models
{
    public class TaxiMap : Map
    {
        public Position CenterPosition
        {
            get => (Position) GetValue(CenterPositionProperty);
            set => SetValue(CenterPositionProperty, value);
        }
        
        public static readonly BindableProperty CenterPositionProperty =
            BindableProperty.Create(propertyName: nameof(CenterPosition), returnType: 
                typeof(Position), declaringType: typeof(TaxiMap), defaultValue: null, 
                propertyChanged: (sender, oldValue, newValue) =>
                {
                    var map = (TaxiMap) sender;

                    if (newValue is Position position)
                    {
                        map.MoveToRegion(MapSpan.FromCenterAndRadius(position, 
                        Distance.FromKilometers(ApiDriver.Default)));
                    }
                });
    }
}