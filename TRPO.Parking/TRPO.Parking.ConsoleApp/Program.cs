using Autofac;
using System;
using System.Collections.Generic;
using TRPO.Parking.Dependencies;
using TRPO.Parking.Logic.Interfaces;

namespace TRPO.Parking.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logic = DependencyResolver.Container.Resolve<ITestLogicInterface>();

            var result = logic.GetTestValue().Result;
            Print(result);

            result = logic.GetGenders().Result;
            Print(result);

            result = logic.GetClientTypes().Result;
            Print(result);

            result = logic.GetRentalRenewalTypes().Result;
            Print(result);

            // --- --- ---
            Console.WriteLine("\nend");
            Console.ReadKey();
        }

        static void Print(IEnumerable<string> entity)
        {
            foreach (var s in entity)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }
    }
}
