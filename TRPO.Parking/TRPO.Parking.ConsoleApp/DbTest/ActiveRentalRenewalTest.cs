using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Utilitas.Pathfinder;

using LActiveRentalRenewal = TRPO.Parking.Entities.ActiveRentalRenewal;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    class ActiveRentalRenewalTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ActiveRentalRenewal:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var activeRentalRenewals = GetAll();
            if (print) Print(activeRentalRenewals);
            var added = Add();
            activeRentalRenewals = GetAll();
            if (print) Print(activeRentalRenewals);

            var equals = IsEqual(added.ToArray(), activeRentalRenewals.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var activeRentalRenewal in db.ActiveRentalRenewals)
                {
                    db.ActiveRentalRenewals.Remove(activeRentalRenewal);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LActiveRentalRenewal> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.ActiveRentalRenewals.Select(ActiveRentalRenewalMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LActiveRentalRenewal> Add()
        {
            var activeRentalRenewals = GetLogicActiveRentalRenewals().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicactiveRental in activeRentalRenewals)
                {
                    var activeRentalRenewal = ActiveRentalRenewalMapper.ToDb(logicactiveRental);
                    db.ActiveRentalRenewals.Add(activeRentalRenewal);
                }

                db.SaveChanges();
            }

            return activeRentalRenewals;
        }

        static IEnumerable<LActiveRentalRenewal> GetLogicActiveRentalRenewals()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                var rentals = db.ActiveRentals.AsNoTracking().ToArray();
                var types = db.RentalRenewalTypes.AsNoTracking().ToArray();

                yield return new LActiveRentalRenewal
                {
                    Rental = ActiveRentalMapper.ToLogic(rentals.FirstOrDefault()),
                    NewEndDate = DateTime.Now,
                    Type = RentalRenewalTypeMapper.ToLogic(types.FirstOrDefault()),
                };

                yield return new LActiveRentalRenewal
                {
                    Rental = ActiveRentalMapper.ToLogic(rentals.LastOrDefault()),
                    NewEndDate = DateTime.Now,
                    Type = RentalRenewalTypeMapper.ToLogic(types.LastOrDefault()),
                };

                yield return new LActiveRentalRenewal
                {
                    Rental = ActiveRentalMapper.ToLogic(rentals.ElementAt(2)),
                    NewEndDate = DateTime.Now,
                    Type = RentalRenewalTypeMapper.ToLogic(types.ElementAt(2)),
                };
            }
        }

        static void Print(IEnumerable<LActiveRentalRenewal> activeRentalRenewals)
        {
            var cnt = 0;
            foreach (var activeRentalRenewal in activeRentalRenewals)
            {
                cnt++;
                Print(activeRentalRenewal);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LActiveRentalRenewal activeRentalRenewal)
        {
            Console.WriteLine($"{activeRentalRenewal.Id})");

            Console.WriteLine($" - Rental.Id: {activeRentalRenewal.Rental.Id}");
            Console.WriteLine($" - NewEndDate: {activeRentalRenewal.NewEndDate}");
            Console.WriteLine($" - Type: {activeRentalRenewal.Type}");

            Console.WriteLine();
        }

        static bool IsEqual(LActiveRentalRenewal[] e1, LActiveRentalRenewal[] e2)
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
