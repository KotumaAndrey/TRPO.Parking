using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Parking.DataBase;
using TRPO.Parking.Dependencies;
//using Autofac;

namespace TRPO.Parking.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test:");

            //var logic = DependencyResolver.Container.Resolve<ITestLogicInterface>();
            //var entity = logic.GetTestValue();

            //Console.WriteLine($"String: {entity.String}");
            //Console.WriteLine($"Length: {entity.Length}");

            using (var db = new ParkingDbContext())
            {
                var t = db.GenderEntities.Select(x => x);
                foreach(var i in t)
                {
                    Console.WriteLine(i.Id);
                }
            }

            // --- --- ---
            Console.WriteLine("\nend");
            Console.ReadKey();
        }
    }
}
