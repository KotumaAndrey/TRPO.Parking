using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using TRPO.Parking.ConsoleApp.DbTest;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Entities;
using TRPO.Parking.Entities.Primitives;
using TRPO.Parking.Utilitas.Pathfinder;

namespace TRPO.Parking.ConsoleApp
{
    class Program
    {
        static IPathfinder pathfinder = Dependencies.DependencyResolver.Container.Resolve<IPathfinder>();
        static void Main(string[] args)
        {
            FullTest.Test(true);

            // --- --- ---
            Console.WriteLine("\nend");
            Console.ReadKey();
        }

        
    }
}
