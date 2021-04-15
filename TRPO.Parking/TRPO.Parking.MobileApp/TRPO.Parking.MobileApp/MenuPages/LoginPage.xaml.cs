using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TRPO.Parking.MobileApp.MenuPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
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
            await Navigation.PushModalAsync(new RegistrationPage(), true);
        }

        private async void ContactsBtn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ContactsPage(), true);
        }

        private async void TestBtn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new TestPages.TestDependencies(), true);
        }
    }
}