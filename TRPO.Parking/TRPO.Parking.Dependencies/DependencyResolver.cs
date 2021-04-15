using Autofac;

namespace TRPO.Parking.Dependencies
{
    public static class DependencyResolver
    {
        private static IContainer _container;

        public static DependencyBuilder Builder { get; } = new DependencyBuilder();

        public static IContainer Container
        {
            get
            {
                if (_container is null)
                {
                    _container = Builder.Build();
                }

                return _container;
            }
        }
    }
}
