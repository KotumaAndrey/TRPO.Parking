using Autofac;
using System.Linq;
using TRPO.Parking.Dependencies;
using TRPO.Parking.Logic.Interfaces;
using Xamarin.Forms;

namespace TRPO.Parking.MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            StackLayout layout = new StackLayout();

            var logic = DependencyResolver.Container.Resolve<ITestLogicInterface>();
            var entity = logic.GetTestValue().Result;
            foreach (var s in entity.Strings)
            {
                Label label = new Label
                {
                    Text = s
                };
                layout.Children.Add(label);
            }

            Content = layout;
        }
    }
}
