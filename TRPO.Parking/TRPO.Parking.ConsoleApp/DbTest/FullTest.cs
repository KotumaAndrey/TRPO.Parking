using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using TRPO.Parking.Utilitas.Pathfinder;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    static class FullTest
    {
        public static void Test(bool print = false)
        {
            IPathfinder pathfinder = Dependencies.DependencyResolver.Container.Resolve<IPathfinder>();
            ClientTest.Test(print, pathfinder);

            AccidentTest.Test(print, pathfinder);
        }
    }
}
