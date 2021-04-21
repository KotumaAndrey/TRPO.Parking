using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Utilitas.Pathfinder;

using LClosedRentalRenewal = TRPO.Parking.Entities.ClosedRentalRenewal;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public class ClosedRentalRenewalTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ClosedRentalRenewal:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var closedRentalRenewals = GetAll();
            if (print) Print(closedRentalRenewals);
            var added = Add();
            closedRentalRenewals = GetAll();
            if (print) Print(closedRentalRenewals);

            var equals = IsEqual(added.ToArray(), closedRentalRenewals.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var closedRentalRenewal in db.ClosedRentalRenewals)
                {
                    db.ClosedRentalRenewals.Remove(closedRentalRenewal);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LClosedRentalRenewal> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.ClosedRentalRenewals.Select(ClosedRentalRenewalMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LClosedRentalRenewal> Add()
        {
            var closedRentalRenewals = GetLogicClosedRentalRenewals().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicclosedRental in closedRentalRenewals)
                {
                    var closedRentalRenewal = ClosedRentalRenewalMapper.ToDb(logicclosedRental);
                    db.ClosedRentalRenewals.Add(closedRentalRenewal);
                }

                db.SaveChanges();
            }

            return closedRentalRenewals;
        }

        static IEnumerable<LClosedRentalRenewal> GetLogicClosedRentalRenewals()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                var rentals = db.ClosedRentals.AsNoTracking().ToArray();
                var types = db.RentalRenewalTypes.AsNoTracking().ToArray();

                yield return new LClosedRentalRenewal
                {
                    Rental = ClosedRentalMapper.ToLogic(rentals.FirstOrDefault()),
                    OldEndDate = new DateTime(2021, 1, 1),
                    NewEndDate = DateTime.Now,
                    Type = RentalRenewalTypeMapper.ToLogic(types.FirstOrDefault()),
                };

                yield return new LClosedRentalRenewal
                {
                    Rental = ClosedRentalMapper.ToLogic(rentals.LastOrDefault()),
                    OldEndDate = new DateTime(2021, 1, 1),
                    NewEndDate = DateTime.Now,
                    Type = RentalRenewalTypeMapper.ToLogic(types.LastOrDefault()),
                };

                yield return new LClosedRentalRenewal
                {
                    Rental = ClosedRentalMapper.ToLogic(rentals.ElementAt(2)),
                    OldEndDate = new DateTime(2021, 1, 1),
                    NewEndDate = DateTime.Now,
                    Type = RentalRenewalTypeMapper.ToLogic(types.ElementAt(2)),
                };
            }
        }

        static void Print(IEnumerable<LClosedRentalRenewal> closedRentalRenewals)
        {
            var cnt = 0;
            foreach (var closedRentalRenewal in closedRentalRenewals)
            {
                cnt++;
                Print(closedRentalRenewal);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LClosedRentalRenewal closedRentalRenewal)
        {
            Console.WriteLine($"{closedRentalRenewal.Id})");

            Console.WriteLine($" - Rental.Id: {closedRentalRenewal.Rental.Id}");
            Console.WriteLine($" - NewEndDate: {closedRentalRenewal.NewEndDate}");
            Console.WriteLine($" - OldEndDate: {closedRentalRenewal.OldEndDate}");
            Console.WriteLine($" - Type: {closedRentalRenewal.Type}");

            Console.WriteLine();
        }

        static bool IsEqual(LClosedRentalRenewal[] e1, LClosedRentalRenewal[] e2)
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
