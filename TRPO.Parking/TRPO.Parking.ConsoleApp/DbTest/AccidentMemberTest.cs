using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Utilitas.Pathfinder;
using Microsoft.EntityFrameworkCore;

using LAccidentMember = TRPO.Parking.Entities.AccidentMember;
using LAccident = TRPO.Parking.Entities.Accident;
using LClient = TRPO.Parking.Entities.Client;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class AccidentMemberTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.WriteLine("Accident:");

            Clear();
            var accidentMembers = GetAll();
            if (print) Print(accidentMembers);
            var added = Add();
            accidentMembers = GetAll();
            if (print) Print(accidentMembers);
            Console.WriteLine($"- {IsEqual(added.ToArray(), accidentMembers.ToArray())}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var accidentMember in db.AccidentMembers)
                {
                    db.AccidentMembers.Remove(accidentMember);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LAccidentMember> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.AccidentMembers.Select(AccidentMemberMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LAccidentMember> Add()
        {
            var accidentMembers = GetLogicAccidents().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicAccidentMember in accidentMembers)
                {
                    var accidentMember = AccidentMemberMapper.ToDb(logicAccidentMember);
                    db.AccidentMembers.Add(accidentMember);
                }

                db.SaveChanges();
            }

            return accidentMembers;
        }

        static IEnumerable<LAccidentMember> GetLogicAccidents()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                yield return new LAccidentMember
                {
                    Accident = AccidentMapper.ToLogic(db.Accidents.AsNoTracking().FirstOrDefault()),
                    Client = ClientMapper.ToLogic(db.Clients.AsNoTracking().OrderBy(e => e.Id).LastOrDefault()),
                };

                yield return new LAccidentMember
                {
                    Accident = AccidentMapper.ToLogic(db.Accidents.AsNoTracking().OrderBy(e => e.Id).LastOrDefault()),
                    Client = ClientMapper.ToLogic(db.Clients.AsNoTracking().FirstOrDefault()),
                };
            }
        }

        static void Print(IEnumerable<LAccidentMember> accidentMembers)
        {
            var cnt = 0;
            foreach (var accidentMember in accidentMembers)
            {
                cnt++;
                Print(accidentMember);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LAccidentMember accidentMember)
        {
            Console.WriteLine($" - Accident.Id: {accidentMember.Accident.Id}");
            Console.WriteLine($" - Client.Id: {accidentMember.Client.Id}");

            Console.WriteLine();
        }

        static bool IsEqual(LAccidentMember[] a1, LAccidentMember[] a2)
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
