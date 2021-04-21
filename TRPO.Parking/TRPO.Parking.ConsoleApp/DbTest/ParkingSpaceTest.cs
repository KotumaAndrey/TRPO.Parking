using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Utilitas.Pathfinder;

using LParkingSpace = TRPO.Parking.Entities.ParkingSpace;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class ParkingSpaceTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ParkingSpace:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var parkingSpaces = GetAll();
            if (print) Print(parkingSpaces);
            var added = Add();
            parkingSpaces = GetAll();
            if (print) Print(parkingSpaces);

            var equals = IsEqual(added.ToArray(), parkingSpaces.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var parkingSpace in db.ParkingSpaces)
                {
                    db.ParkingSpaces.Remove(parkingSpace);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LParkingSpace> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.ParkingSpaces.Select(ParkingSpaceMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LParkingSpace> Add()
        {
            var parkingSpaces = GetLogicParkingSpaces().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicParkingSpace in parkingSpaces)
                {
                    var parkingSpace = ParkingSpaceMapper.ToDb(logicParkingSpace);
                    db.ParkingSpaces.Add(parkingSpace);
                }

                db.SaveChanges();
            }

            return parkingSpaces;
        }

        static IEnumerable<LParkingSpace> GetLogicParkingSpaces()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                List<LParkingSpace> parkingSpaces = new List<LParkingSpace>();

                for (int i = 1; i <= 10; i++)
                {
                    parkingSpaces.Add(new LParkingSpace
                    {
                        Floor = FloorMapper.ToLogic(db.Floors.AsNoTracking().FirstOrDefault()),
                        Row = 1,
                        Colunm = i,
                        Status = Entities.Primitives.ParkingSpaceStatus.Free
                    });
                }

                return parkingSpaces;
            }
        }

        static void Print(IEnumerable<LParkingSpace> parkingSpaces)
        {
            var cnt = 0;
            foreach (var parkingSpace in parkingSpaces)
            {
                cnt++;
                Print(parkingSpace);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LParkingSpace parkingSpace)
        {
            Console.WriteLine($"{parkingSpace.Id}) {parkingSpace.Status}");

            Console.WriteLine($" - Floor.Id: {parkingSpace.Floor.Id}");
            Console.WriteLine($" - Row: {parkingSpace.Row}");
            Console.WriteLine($" - Column: {parkingSpace.Colunm}");

            Console.WriteLine();
        }

        static bool IsEqual(LParkingSpace[] e1, LParkingSpace[] e2)
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
