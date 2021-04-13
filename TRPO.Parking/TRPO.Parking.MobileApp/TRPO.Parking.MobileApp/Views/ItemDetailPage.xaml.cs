using System.ComponentModel;
using TRPO.Parking.MobileApp.ViewModels;
using Xamarin.Forms;

namespace TRPO.Parking.MobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}