using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TRPO.Parking.MobileApp.ParkingPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParkingPage : ContentPage
    {
        public ParkingPage()
        {
            InitializeComponent();

            StackLayout layout = new StackLayout();

            layout.Children.Add(new Label
            {
                Text = "1"
            });
            layout.Children.Add(new Label
            {
                Text = "2"
            });
            layout.Children.Add(new Label
            {
                Text = "3"
            });
            layout.Children.Add(new Label
            {
                Text = Shell.Current?.ToString() ?? "<null>"
            });
            layout.Children.Add(new Label
            {
                Text = (App.Current.MainPage as Shell)?.ToString() ?? "<null>"
            });

            Content = layout;
        }
    }
}