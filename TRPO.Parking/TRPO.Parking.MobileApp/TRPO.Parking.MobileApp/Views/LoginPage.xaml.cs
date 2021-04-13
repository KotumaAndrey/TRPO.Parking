using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Parking.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TRPO.Parking.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
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