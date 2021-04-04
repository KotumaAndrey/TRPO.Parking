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
            StackLayout stackLayout = new StackLayout();

            loginEntry = new Entry { Placeholder = "Login" };
            loginEntry.TextChanged += loginEntry_TextChanged;

            passwordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true
            };
            textLabel = new Label { FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) };
            stackLayout.Children.Add(Title);
            stackLayout.Children.Add(loginEntry);
            stackLayout.Children.Add(passwordEntry);
            stackLayout.Children.Add(textLabel);
            stackLayout.Children.Add(EnterBtn);
            stackLayout.Children.Add(RegistrationBtn);
            stackLayout.Children.Add(ContactsBtn);


            this.Content = stackLayout;
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
            await Navigation.PushModalAsync(new RegistrationPage(), false);
        }
        private void ContactsBtn_Clicked(object sender, System.EventArgs e)
        {

        }

    }
}
