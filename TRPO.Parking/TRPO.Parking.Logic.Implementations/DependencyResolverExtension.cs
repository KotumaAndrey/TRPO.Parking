using Autofac;
using TRPO.Parking.Logic.Interfaces;

namespace TRPO.Parking.Logic.Implementations
{
    public static class DependencyResolverExtension
    {
        public static void RegisterLogics(this ContainerBuilder builder)
        {
            builder.RegisterType<TestLogicClass>().As<ITestLogicInterface>();
        }
    }
}
