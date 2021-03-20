using Autofac;
using TRPO.Parking.Logic.Implementations;
using TRPO.Parking.Repositories.Implementations;

namespace TRPO.Parking.Dependencies
{
    public static class DependencyResolver
    {
        public static IContainer Container { get; private set; }

        static DependencyResolver()
        {
            var builder = new ContainerBuilder();

            builder.RegisterRepositories();
            builder.RegisterLogics();

            Container = builder.Build();
        }
    }
}
