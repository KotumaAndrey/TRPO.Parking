using TRPO.Parking.MobileApp.MenuPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TRPO.Parking.MobileApp.AuthenticationPages
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

        private async void EnterBtn_Clicked(object sender, System.EventArgs e)
        {
            // smth
            await Navigation.PushModalAsync(new ParkingPages.ParkingPage(), true);
        }

        private async void RegistrationBtn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistrationPage(), true);
        }

        private async void ContactsBtn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new AboutPage(), true);
        }

        private async void TestBtn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new TestPages.TestDependencies(), true);
        }
    }
}