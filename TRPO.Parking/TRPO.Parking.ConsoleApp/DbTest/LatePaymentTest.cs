using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Entities.Primitives;
using TRPO.Parking.Utilitas.Pathfinder;

using LLatePayment = TRPO.Parking.Entities.LatePayment;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class LatePaymentTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("LatePayment:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var latePayments = GetAll();
            if (print) Print(latePayments);
            var added = Add();
            latePayments = GetAll();
            if (print) Print(latePayments);

            var equals = IsEqual(added.ToArray(), latePayments.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var latePayment in db.LatePayments)
                {
                    db.LatePayments.Remove(latePayment);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LLatePayment> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.LatePayments.Select(LatePaymentMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LLatePayment> Add()
        {
            var latePayments = GetLogicLatePayments().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicLatePayment in latePayments)
                {
                    var latePayment = LatePaymentMapper.ToDb(logicLatePayment);
                    db.LatePayments.Add(latePayment);
                }

                db.SaveChanges();
            }

            return latePayments;
        }

        static IEnumerable<LLatePayment> GetLogicLatePayments()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                var clients = db.Clients.AsNoTracking().ToArray();
                var latePaymentTypes = db.LatePaymentTypes.AsNoTracking().ToArray();
                var parkingSpaces = db.ParkingSpaces.AsNoTracking().ToArray();
                var activeRentals = db.ActiveRentals.AsNoTracking().ToArray();
                var closedRentals = db.ClosedRentals.AsNoTracking().ToArray();
                var t = latePaymentTypes.FirstOrDefault();

                yield return new LLatePayment
                {
                    Client = ClientMapper.ToLogic(clients.FirstOrDefault()),
                    LatePaymentType = LatePaymentTypeMapper.ToLogic(latePaymentTypes.FirstOrDefault()),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.FirstOrDefault()),
                    ActiveRental = ActiveRentalMapper.ToLogic(activeRentals.FirstOrDefault()),
                    ClosedRental = ClosedRentalMapper.ToLogic(closedRentals.FirstOrDefault()),
                };

                yield return new LLatePayment
                {
                    Client = ClientMapper.ToLogic(clients.LastOrDefault()),
                    LatePaymentType = LatePaymentTypeMapper.ToLogic(latePaymentTypes.LastOrDefault()),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.LastOrDefault()),
                    ActiveRental = ActiveRentalMapper.ToLogic(activeRentals.FirstOrDefault()),
                    ClosedRental = ClosedRentalMapper.ToLogic(closedRentals.LastOrDefault()),
                };

                yield return new LLatePayment
                {
                    Client = ClientMapper.ToLogic(clients.ElementAt(3)),
                    LatePaymentType = LatePaymentTypeMapper.ToLogic(latePaymentTypes.ElementAt(3)),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.ElementAt(3)),
                    ActiveRental = ActiveRentalMapper.ToLogic(activeRentals.ElementAt(3)),
                    ClosedRental = ClosedRentalMapper.ToLogic(closedRentals.ElementAt(3)),
                };
            }
        }

        static void Print(IEnumerable<LLatePayment> latePayments)
        {
            var cnt = 0;
            foreach (var latePayment in latePayments)
            {
                cnt++;
                Print(latePayment);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LLatePayment latePayment)
        {
            Console.WriteLine($"{latePayment.Id})");

            Console.WriteLine($" - Client.Id: {latePayment.Client.Id}");
            Console.WriteLine($" - LatePaymentType.Id: {latePayment.LatePaymentType.Id}");
            Console.WriteLine($" - ParkingSpace.Id: {latePayment.ParkingSpace.Id}");
            Console.WriteLine($" - ActiveRental.Id: {latePayment.ActiveRental.Id}");
            Console.WriteLine($" - ClosedRental.Id: {latePayment.ClosedRental.Id}");

            Console.WriteLine();
        }

        static bool IsEqual(LLatePayment[] e1, LLatePayment[] e2)
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
