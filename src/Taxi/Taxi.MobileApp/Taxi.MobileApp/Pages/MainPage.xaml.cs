using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.MobileApp.Models;
using Taxi.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Taxi.MobileApp.Pages
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Pin_OnMarkerClicked(object sender, PinClickedEventArgs e)
        {
            if (BindingContext is MainViewModel model)
            {
                model.MarkerClickedCommand?.Execute((CustomPin) sender);
            }
        }
    }
}
