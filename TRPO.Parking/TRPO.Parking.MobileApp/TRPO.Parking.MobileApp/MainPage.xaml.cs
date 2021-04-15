using Autofac;
using System.Linq;
using TRPO.Parking.Dependencies;
using TRPO.Parking.Entities;
using TRPO.Parking.Logic.Interfaces;
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
            await Navigation.PushModalAsync(new RegistrationPage(), true);
        }

        private async void ContactsBtn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ContactsPage(), true);
        }

        private async void TestBtn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new TestDependencies(), true);
        }
    }
}
