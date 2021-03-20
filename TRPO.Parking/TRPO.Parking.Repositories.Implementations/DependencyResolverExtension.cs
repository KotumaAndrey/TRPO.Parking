using Autofac;
using TRPO.Parking.Repositories.Interfaces;

namespace TRPO.Parking.Repositories.Implementations
{
    public static class DependencyResolverExtension
    {
        public static void RegisterRepositories(this ContainerBuilder builder)
        {
            builder.RegisterType<TestRepoClass>().As<ITestRepoInterface>();
        }
    }
}
