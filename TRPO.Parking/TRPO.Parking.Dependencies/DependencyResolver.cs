using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO.Parking.Dependencies
{
    public class DependencyResolver
    {
        public static IContainer Container { get; private set; }

        static DependencyResolver()
        {
            var builder = new ContainerBuilder();

            // smth

            Container = builder.Build();
        }
    }
}
