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

        async void OnButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("АСТАРОЖНА", "Вы включили телефон, а он не настоящий!1!", "Ок", "Не ок");
        }
    }
}
