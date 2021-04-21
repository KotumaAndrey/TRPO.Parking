using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Utilitas.Pathfinder;

using LActiveRantal = TRPO.Parking.Entities.ActiveRental;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class ActiveRentalTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.WriteLine("Accident:");

            Clear();
            var activeRentals = GetAll();
            if (print) Print(activeRentals);
            var added = Add();
            activeRentals = GetAll();
            if (print) Print(activeRentals);
            Console.WriteLine($"- {IsEqual(added.ToArray(), activeRentals.ToArray())}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var activeRental in db.ActiveRentals)
                {
                    db.ActiveRentals.Remove(activeRental);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LActiveRantal> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.ActiveRentals.Select(ActiveRentalMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LActiveRantal> Add()
        {
            var activeRentals = GetLogicAccidents().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicactiveRental in activeRentals)
                {
                    var activeRental = ActiveRentalMapper.ToDb(logicactiveRental);
                    db.ActiveRentals.Add(activeRental);
                }

                db.SaveChanges();
            }

            return activeRentals;
        }

        static IEnumerable<LActiveRantal> GetLogicAccidents()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                yield return new LActiveRantal
                {

                };
            }
        }

        static void Print(IEnumerable<LActiveRantal> activeRentals)
        {
            var cnt = 0;
            foreach (var activeRental in activeRentals)
            {
                cnt++;
                Print(activeRental);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LActiveRantal activeRental)
        {
            Console.WriteLine($"{activeRental.Id})");

            Console.WriteLine($" - Client.Id: {activeRental.Client.Id}");
            Console.WriteLine($" - ParkingSpace.Id: {activeRental.ParkingSpace.Id}");

            Console.WriteLine($" - OpenDate: {activeRental.OpenDate}");
            Console.WriteLine($" - ExpectedCloseDate: {activeRental.ExpectedCloseDate}");

            Console.WriteLine();
        }

        static bool IsEqual(LActiveRantal[] a1, LActiveRantal[] a2)
        {
            if (a1.Length != a2.Length) return false;

            for (int i = 0; i < a1.Length; i++)
            {
                if (!TestExt.IsEqual(a1[i], a2[i])) return false;
            }

            return true;
        }
    }
}
