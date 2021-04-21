using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Utilitas.Pathfinder;

using LClosedRantal = TRPO.Parking.Entities.ClosedRental;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class ClosedRentalTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ClosedRental:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var closedRentals = GetAll();
            if (print) Print(closedRentals);
            var added = Add();
            closedRentals = GetAll();
            if (print) Print(closedRentals);

            var equals = IsEqual(added.ToArray(), closedRentals.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var closedRental in db.ClosedRentals)
                {
                    db.ClosedRentals.Remove(closedRental);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LClosedRantal> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.ClosedRentals.Select(ClosedRentalMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LClosedRantal> Add()
        {
            var closedRentals = GetLogicClosedRentals().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicclosedRental in closedRentals)
                {
                    var closedRental = ClosedRentalMapper.ToDb(logicclosedRental);
                    db.ClosedRentals.Add(closedRental);
                }

                db.SaveChanges();
            }

            return closedRentals;
        }

        static IEnumerable<LClosedRantal> GetLogicClosedRentals()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                var clients = db.Clients.AsNoTracking().ToArray();
                var parkingSpaces = db.ParkingSpaces.AsNoTracking().ToArray();

                yield return new LClosedRantal
                {
                    Client = ClientMapper.ToLogic(clients.FirstOrDefault()),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.FirstOrDefault()),
                    OpenDate = new DateTime(2021, 03, 10, 10, 34, 10),
                    ExpectedCloseDate = new DateTime(2021, 03, 10, 11, 34, 10),
                    RealCloseDate = new DateTime(2021, 03, 10, 11, 34, 10),
                    Price = 10
                };

                yield return new LClosedRantal
                {
                    Client = ClientMapper.ToLogic(clients.OrderBy(c => c.Id).LastOrDefault()),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.ElementAt(2)),
                    OpenDate = new DateTime(2021, 03, 10, 10, 34, 10),
                    ExpectedCloseDate = new DateTime(2021, 03, 10, 11, 34, 10),
                    RealCloseDate = new DateTime(2021, 03, 10, 11, 34, 10),
                    Price = 777
                };

                yield return new LClosedRantal
                {
                    Client = ClientMapper.ToLogic(clients.ElementAt(3)),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.ElementAt(3)),
                    OpenDate = new DateTime(2021, 03, 10, 10, 34, 10),
                    ExpectedCloseDate = new DateTime(2021, 03, 10, 11, 34, 10),
                    RealCloseDate = new DateTime(2021, 03, 10, 11, 34, 10),
                    Price = 33
                };

                yield return new LClosedRantal
                {
                    Client = ClientMapper.ToLogic(clients.ElementAt(6)),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.ElementAt(4)),
                    OpenDate = new DateTime(2021, 03, 10, 10, 34, 10),
                    ExpectedCloseDate = new DateTime(2021, 03, 10, 11, 34, 10),
                    RealCloseDate = new DateTime(2021, 03, 10, 11, 34, 10),
                    Price = 100
                };
            }
        }

        static void Print(IEnumerable<LClosedRantal> closedRentals)
        {
            var cnt = 0;
            foreach (var closedRental in closedRentals)
            {
                cnt++;
                Print(closedRental);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LClosedRantal closedRental)
        {
            Console.WriteLine($"{closedRental.Id})");

            Console.WriteLine($" - Client.Id: {closedRental.Client.Id}");
            Console.WriteLine($" - ParkingSpace.Id: {closedRental.ParkingSpace.Id}");

            Console.WriteLine($" - OpenDate: {closedRental.OpenDate}");
            Console.WriteLine($" - ExpectedCloseDate: {closedRental.ExpectedCloseDate}");
            Console.WriteLine($" - RealCloseDate: {closedRental.RealCloseDate}");
            Console.WriteLine($" - Price: {closedRental.Price}");

            Console.WriteLine();
        }

        static bool IsEqual(LClosedRantal[] e1, LClosedRantal[] e2)
        {
            if (e1.Length != e2.Length) return false;

            for (int i = 0; i < e1.Length; i++)
            {
                if (!TestExt.IsEqual(e1[i], e2[i])) return false;
            }

            return true;
        }
    }
}
