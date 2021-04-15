using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.EntityFrameworkCore;
using TRPO.Parking.DataBase;
using TRPO.Parking.Dependencies;
using TRPO.Parking.Entities;
using TRPO.Parking.Logic.Interfaces;

namespace TRPO.Parking.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logic = DependencyResolver.Container.Resolve<ITestLogicInterface>();

            var entity = logic.GetTestValue().Result;
            Print(entity);

            entity = logic.GetGenders().Result;
            Print(entity);

            entity = logic.GetClientTypes().Result;
            Print(entity);

            entity = logic.GetRentalRenewalTypes().Result;
            Print(entity);

            // --- --- ---
            Console.WriteLine("\nend");
            Console.ReadKey();
        }

        static void Print(TestEntity entity)
        {
            foreach (var s in entity.Strings)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }
    }
}
