using Autofac;
using TRPO.Parking.Dependencies;
using TRPO.Parking.Entities;
using TRPO.Parking.Logic.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TRPO.Parking.MobileApp.TestPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestDependencies : ContentPage
    {
        public TestDependencies()
        {
            InitializeComponent();

            StackLayout layout = new StackLayout();

            var logic = DependencyResolver.Container.Resolve<ITestLogicInterface>();

            var entity = logic.GetTestValue().Result;
            var render = RenderEntity(entity);
            layout.Children.Add(render);

            entity = logic.GetGenders().Result;
            render = RenderEntity(entity);
            layout.Children.Add(render);

            entity = logic.GetClientTypes().Result;
            render = RenderEntity(entity);
            layout.Children.Add(render);

            entity = logic.GetRentalRenewalTypes().Result;
            render = RenderEntity(entity);
            layout.Children.Add(render);

            Button button = new Button()
            {
                Text = "back",
            };
            button.Clicked += BackBtn_Clicked;
            layout.Children.Add(button);

            Content = layout;
        }

        private StackLayout RenderEntity(TestEntity entity)
        {
            var layout = new StackLayout
            {
                Margin = new Thickness(10)
            };

            foreach (var s in entity.Strings)
            {
                Label label = new Label
                {
                    Text = s
                };
                layout.Children.Add(label);
            }

            return layout;
        }

        private async void BackBtn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}