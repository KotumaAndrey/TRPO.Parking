using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Utilitas.Pathfinder;

using LFloor = TRPO.Parking.Entities.Floor;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class FloorTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Floor:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var floors = GetAll();
            if (print) Print(floors);
            var added = Add();
            floors = GetAll();
            if (print) Print(floors);

            var equals = IsEqual(added.ToArray(), floors.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var floor in db.Floors)
                {
                    db.Floors.Remove(floor);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LFloor> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.Floors.Select(FloorMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LFloor> Add()
        {
            var floors = GetLogicFloors().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicFloor in floors)
                {
                    var floor = FloorMapper.ToDb(logicFloor);
                    db.Floors.Add(floor);
                }

                db.SaveChanges();
            }

            return floors;
        }

        static IEnumerable<LFloor> GetLogicFloors()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                List<LFloor> floors = new List<LFloor>();

                for (int i = 1; i <= 5; i++)
                {
                    floors.Add(new LFloor
                    {
                        RowCount = 4,
                        ColumnCount = 32,
                    });
                }

                return floors;
            }
        }

        static void Print(IEnumerable<LFloor> floors)
        {
            var cnt = 0;
            foreach (var floor in floors)
            {
                cnt++;
                Print(floor);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LFloor floor)
        {
            Console.WriteLine($"{floor.Id})");

            Console.WriteLine($" - RowCount: {floor.RowCount}");
            Console.WriteLine($" - ColumnCount: {floor.ColumnCount}");

            Console.WriteLine();
        }

        static bool IsEqual(LFloor[] e1, LFloor[] e2)
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
