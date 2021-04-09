using System;
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

            //var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            //foreach (var assembly in assemblies)
            //{
            //    Console.WriteLine(assembly.FullName);
            //}

            builder.RegisterRepositories();
            builder.RegisterLogics();

            Container = builder.Build();
        }
    }
}
