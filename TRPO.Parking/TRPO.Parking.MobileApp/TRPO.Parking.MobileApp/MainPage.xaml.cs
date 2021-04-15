using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TRPO.Parking.MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void loginEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            textLabel.Text = loginEntry.Text;
        }
        private void EnterBtn_Clicked(object sender, System.EventArgs e)
        {
        }
        private async void RegistrationBtn_Clicked(object sender, System.EventArgs e)
        {
            // Page appearance not animated
            await Navigation.PushModalAsync(new RegistrationPage(), true);
        }
        private async void ContactsBtn_Clicked(object sender, System.EventArgs e)
        {
            // Page appearance not animated
            await Navigation.PushModalAsync(new ContactsPage(), true);
        }

    }
}
