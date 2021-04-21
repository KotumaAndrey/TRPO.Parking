using System;
using System.Collections.Generic;
using System.Linq;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Entities.Primitives;
using TRPO.Parking.Utilitas.Pathfinder;

using LLatePaymentType = TRPO.Parking.Entities.LatePaymentType;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class LatePaymentTypeTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("LatePaymentType:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var latePaymentTypes = GetAll();
            if (print) Print(latePaymentTypes);
            var added = Add();
            latePaymentTypes = GetAll();
            if (print) Print(latePaymentTypes);

            var equals = IsEqual(added.ToArray(), latePaymentTypes.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var latePaymentType in db.LatePaymentTypes)
                {
                    db.LatePaymentTypes.Remove(latePaymentType);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LLatePaymentType> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.LatePaymentTypes.Select(LatePaymentTypeMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LLatePaymentType> Add()
        {
            var latePaymentTypes = GetLogicLatePaymentTypes().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicLatePaymentType in latePaymentTypes)
                {
                    var latePaymentType = LatePaymentTypeMapper.ToDb(logicLatePaymentType);
                    db.LatePaymentTypes.Add(latePaymentType);
                }

                db.SaveChanges();
            }

            return latePaymentTypes;
        }

        static IEnumerable<LLatePaymentType> GetLogicLatePaymentTypes()
        {
            List<LLatePaymentType> latePaymentTypes = new List<LLatePaymentType>();

            latePaymentTypes.Add(new LLatePaymentType
            {
                PriceMultiplier = 1,
                From = 0,
                To = 20,
            });

            //yield return new LLatePaymentType
            //{
            //    PriceMultiplier = 1,
            //    From = 0,
            //    To = 20,
            //};

            //yield return new LLatePaymentType
            //{
            //    PriceMultiplier = 2,
            //    From = 21,
            //    To = 40,
            //};

            //yield return new LLatePaymentType
            //{
            //    PriceMultiplier = 3,
            //    From = 41,
            //    To = 60,
            //};

            //yield return new LLatePaymentType
            //{
            //    PriceMultiplier = 4,
            //    From = 61,
            //    To = 80,
            //};

            //yield return new LLatePaymentType
            //{
            //    PriceMultiplier = 5,
            //    From = 81,
            //    To = 100,
            //};

            return latePaymentTypes;
        }

        static void Print(IEnumerable<LLatePaymentType> latePaymentTypes)
        {
            var cnt = 0;
            foreach (var latePaymentType in latePaymentTypes)
            {
                cnt++;
                Print(latePaymentType);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LLatePaymentType latePaymentType)
        {
            Console.WriteLine($"{latePaymentType.Id})");

            Console.WriteLine($" - PriceMultiplier: {latePaymentType.PriceMultiplier}");
            Console.WriteLine($" - From: {latePaymentType.From}");
            Console.WriteLine($" - To: {latePaymentType.To}");

            Console.WriteLine();
        }

        static bool IsEqual(LLatePaymentType[] e1, LLatePaymentType[] e2)
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
