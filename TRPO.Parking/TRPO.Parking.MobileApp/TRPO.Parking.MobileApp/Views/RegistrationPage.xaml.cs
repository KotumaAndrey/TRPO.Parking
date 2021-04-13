using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TRPO.Parking.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void firstNameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void lastNameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void phoneNumberEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void RegistrationBtn_Clicked(object sender, System.EventArgs e)
        {

        }
        private async void BackBtn_Clicked(object sender, System.EventArgs e)
        {
            // Page appearance not animated
            await Navigation.PopModalAsync();
        }
    }
}