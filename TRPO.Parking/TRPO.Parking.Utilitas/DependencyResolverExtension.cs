using Autofac;
using TRPO.Parking.Utilitas.Pathfinder;

namespace TRPO.Parking.Utilitas
{
    public static class DependencyResolverExtension
    {
        public static void RegisterUtilitas(this ContainerBuilder builder)
        {
            builder.RegisterType<BasePathfinder>().As<IPathfinder>();
        }
    }
}
