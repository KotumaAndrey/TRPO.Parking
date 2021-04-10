using Autofac;
using Autofac.Builder;
using TRPO.Parking.Logic.Implementations;
using TRPO.Parking.Repositories.Implementations;
using TRPO.Parking.Utilitas;
using TRPO.Parking.Utilitas.Pathfinder;

namespace TRPO.Parking.Dependencies
{
    public class DependencyBuilder
    {
        private ContainerBuilder _builder;

        public DependencyBuilder()
        {
            _builder = new ContainerBuilder();

            _builder.RegisterUtilitas();
            _builder.RegisterRepositories();
            _builder.RegisterLogics();
        }

        public IContainer Build()
        {
            return _builder.Build();
        }

        public void Register<InterfaceType, ImplementationType>() 
            where ImplementationType : InterfaceType
        {
            _builder.RegisterType<ImplementationType>().As<InterfaceType>();
        }
    }
}
