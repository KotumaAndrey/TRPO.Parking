using TRPO.Parking.Dependencies;
using TRPO.Parking.Utilitas.Pathfinder;
using Xamarin.Forms;

namespace TRPO.Parking.MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            DependencyResolver.Builder.Register<IPathfinder, AndroidFilePathfinder>();

            InitializeComponent();

            MainPage = new AppShell(); //AuthenticationPages.LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
