﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ActiveRental:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var activeRentals = GetAll();
            if (print) Print(activeRentals);
            var added = Add();
            activeRentals = GetAll();
            if (print) Print(activeRentals);

            var equals = IsEqual(added.ToArray(), activeRentals.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
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
            var activeRentals = GetLogicActiveRentals().ToArray();
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

        static IEnumerable<LActiveRantal> GetLogicActiveRentals()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                var clients = db.Clients.AsNoTracking().ToArray();
                var parkingSpaces = db.ParkingSpaces.AsNoTracking().ToArray();

                yield return new LActiveRantal
                {
                    Client = ClientMapper.ToLogic(clients.FirstOrDefault()),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.FirstOrDefault()),
                    OpenDate = new DateTime(2021, 03, 10, 10, 34, 10),
                    ExpectedCloseDate = new DateTime(2021, 03, 10, 11, 34, 10)
                };

                yield return new LActiveRantal
                {
                    Client = ClientMapper.ToLogic(clients.OrderBy(c => c.Id).LastOrDefault()),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.ElementAt(2)),
                    OpenDate = new DateTime(2021, 03, 10, 10, 34, 10),
                    ExpectedCloseDate = new DateTime(2021, 03, 10, 11, 34, 10)
                };

                yield return new LActiveRantal
                {
                    Client = ClientMapper.ToLogic(clients.ElementAt(3)),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.ElementAt(3)),
                    OpenDate = new DateTime(2021, 03, 10, 10, 34, 10),
                    ExpectedCloseDate = new DateTime(2021, 03, 10, 11, 34, 10)
                };

                yield return new LActiveRantal
                {
                    Client = ClientMapper.ToLogic(clients.ElementAt(6)),
                    ParkingSpace = ParkingSpaceMapper.ToLogic(parkingSpaces.ElementAt(4)),
                    OpenDate = new DateTime(2021, 03, 10, 10, 34, 10),
                    ExpectedCloseDate = new DateTime(2021, 03, 10, 11, 34, 10)
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

        static bool IsEqual(LActiveRantal[] e1, LActiveRantal[] e2)
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