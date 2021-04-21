using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Utilitas.Pathfinder;

using LActiveRentalParkingSpaces = TRPO.Parking.Entities.ActiveRentalParkingSpaces;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class ActiveRentalParkingSpacesTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ActiveRentalParkingSpace:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var activeRentalParkingSpaces = GetAll();
            if (print) Print(activeRentalParkingSpaces);
            var added = Add();
            activeRentalParkingSpaces = GetAll();
            if (print) Print(activeRentalParkingSpaces);

            var equals = IsEqual(added.ToArray(), activeRentalParkingSpaces.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var activeRentalParkingSpace in db.ActiveRentalParkingSpaces)
                {
                    db.ActiveRentalParkingSpaces.Remove(activeRentalParkingSpace);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LActiveRentalParkingSpaces> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.ActiveRentalParkingSpaces.Select(ActiveRentalParkingSpacesMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LActiveRentalParkingSpaces> Add()
        {
            var activeRentalParkingSpaces = GetLogicActiveRentalParkingSpaces().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicActiveRentalParkingSpace in activeRentalParkingSpaces)
                {
                    var activeRentalParkingSpace = ActiveRentalParkingSpacesMapper.ToDb(logicActiveRentalParkingSpace);
                    db.ActiveRentalParkingSpaces.Add(activeRentalParkingSpace);
                }

                db.SaveChanges();
            }

            return activeRentalParkingSpaces;
        }

        static IEnumerable<LActiveRentalParkingSpaces> GetLogicActiveRentalParkingSpaces()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                var activeRentals = db.ActiveRentals.AsNoTracking().ToArray();
                var parkingSpaces = db.ParkingSpaces.AsNoTracking().ToArray();

                yield return new LActiveRentalParkingSpaces
                {
                    ActiveRental = ActiveRentalMapper.ToLogic(activeRentals.FirstOrDefault()),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.FirstOrDefault()),
                };

                yield return new LActiveRentalParkingSpaces
                {
                    ActiveRental = ActiveRentalMapper.ToLogic(activeRentals.LastOrDefault()),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.LastOrDefault()),
                };

                yield return new LActiveRentalParkingSpaces
                {
                    ActiveRental = ActiveRentalMapper.ToLogic(activeRentals.ElementAt(3)),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.ElementAt(3)),
                };
            }
        }

        static void Print(IEnumerable<LActiveRentalParkingSpaces> activeRentalParkingSpaces)
        {
            var cnt = 0;
            foreach (var activeRentalParkingSpace in activeRentalParkingSpaces)
            {
                cnt++;
                Print(activeRentalParkingSpace);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LActiveRentalParkingSpaces activeRentalParkingSpace)
        {
            Console.WriteLine($" - {activeRentalParkingSpace.ActiveRental.Id})");
            Console.WriteLine($" - {activeRentalParkingSpace.ParkingSpace.Id})");

            Console.WriteLine();
        }

        static bool IsEqual(LActiveRentalParkingSpaces[] e1, LActiveRentalParkingSpaces[] e2)
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
