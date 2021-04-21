using System;
using System.Collections.Generic;
using TRPO.Parking.Utilitas.Pathfinder;
using System.Linq;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using Microsoft.EntityFrameworkCore;

using LAccident = TRPO.Parking.Entities.Accident;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class AccidentTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.WriteLine("Accident:");

            Clear();
            var accidents = GetAll();
            if (print) Print(accidents);
            var added = Add();
            accidents = GetAll();
            if (print) Print(accidents);
            Console.WriteLine($"- {IsEqual(added.ToArray(), accidents.ToArray())}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var accident in db.Accidents)
                {
                    db.Accidents.Remove(accident);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LAccident> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.Accidents.Select(AccidentMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LAccident> Add()
        {
            var accidents = GetLogicAccidents().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicAccident in accidents)
                {
                    var accident = AccidentMapper.ToDb(logicAccident);
                    db.Accidents.Add(accident);
                }

                db.SaveChanges();
            }

            return accidents;
        }

        static IEnumerable<LAccident> GetLogicAccidents()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                yield return new LAccident
                {
                    AccidentDate = DateTime.Now,
                    CulpritClient = ClientMapper.ToLogic(db.Clients.AsNoTracking().FirstOrDefault()),
                    Comment = "Test accident #1.",
                };

                yield return new LAccident
                {
                    AccidentDate = new DateTime(2021, 1, 20),
                    CulpritClient = ClientMapper.ToLogic(db.Clients.AsNoTracking().ToList().ElementAt(3)),
                    Comment = "Test accident #2."
                };

                yield return new LAccident
                {
                    AccidentDate = new DateTime(2021, 3, 14),
                    CulpritClient = ClientMapper.ToLogic(db.Clients.AsNoTracking().OrderBy(c => c.Id).LastOrDefault()),
                    Comment = "Test accident #3."

                };
            }
        }

        static void Print(IEnumerable<LAccident> accidents)
        {
            var cnt = 0;
            foreach (var accident in accidents)
            {
                cnt++;
                Print(accident);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LAccident accident)
        {
            Console.WriteLine($"{accident.Id})");

            Console.WriteLine($" - AccidentDate: {accident.AccidentDate}");
            Console.WriteLine($" - CulpritClient.Id: {accident.CulpritClient.Id}");
            Console.WriteLine($" - AccidentDate: {accident.AccidentDate}");

            Console.WriteLine();
        }

        static bool IsEqual(LAccident[] a1, LAccident[] a2)
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
