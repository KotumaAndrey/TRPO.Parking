using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TRPO.Parking.MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(AuthenticationPages.LoginPage));
            Routing.RegisterRoute("parking", typeof(ParkingPages.ParkingPage));
        }

        private async void MenuItem_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("", "Привет Хабр!", "OK");
        }
    }
}