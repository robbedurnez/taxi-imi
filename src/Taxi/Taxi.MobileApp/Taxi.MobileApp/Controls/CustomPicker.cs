using Xamarin.Forms;

namespace Taxi.MobileApp.Controls
{
    public class CustomPicker : Picker
    {
        public static readonly BindableProperty NewBackgroundColorProperty =  
            BindableProperty.Create(nameof(NewBackgroundColor),  
                typeof(Color),typeof(CustomPicker),Color.Gray);  
        
        public Color NewBackgroundColor
        {   get => (Color)GetValue(NewBackgroundColorProperty);   
            set => SetValue(NewBackgroundColorProperty, value);   
        }
        
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(CustomPicker), 0);

        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        
        public CustomPicker()
        {
        }
    }
}