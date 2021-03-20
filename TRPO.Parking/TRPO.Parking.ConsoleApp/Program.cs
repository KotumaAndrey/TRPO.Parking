using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Parking.Dependencies;
using Autofac;
using TRPO.Parking.Logic.Interfaces;

namespace TRPO.Parking.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test:");

            var logic = DependencyResolver.Container.Resolve<ITestLogicInterface>();
            var entity = logic.GetTestValue();

            Console.WriteLine($"String: {entity.String}");
            Console.WriteLine($"Length: {entity.Length}");

            // --- --- ---
            Console.WriteLine("\nend");
            Console.ReadKey();
        }
    }
}
