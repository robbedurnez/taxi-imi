using Xamarin.Forms;

namespace Taxi.MobileApp.Controls
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty NewBackgroundColorProperty =  
            BindableProperty.Create(nameof(NewBackgroundColor),  
                typeof(Color),typeof(CustomEntry),Color.Gray);  
        
        public Color NewBackgroundColor
        {   
            get => (Color)GetValue(NewBackgroundColorProperty);   
            set => SetValue(NewBackgroundColorProperty, value);   
        }

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        
        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }
        
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(CustomEntry));

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CustomEntry));

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(CustomEntry), 0);

        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        
        public CustomEntry()
        {
        }
    }
}