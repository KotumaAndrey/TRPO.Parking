using System;
using System.Collections.Generic;
using System.Linq;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Entities.Primitives;
using TRPO.Parking.Utilitas.Pathfinder;

using LClientTypeEntity = TRPO.Parking.Entities.ClientTypeEntity;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class ClientTypeEntityTypeEntityTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ClientTypeEntity:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var clientTypeEntityTypeEntities = GetAll();
            if (print) Print(clientTypeEntityTypeEntities);
            var added = Add();
            clientTypeEntityTypeEntities = GetAll();
            if (print) Print(clientTypeEntityTypeEntities);

            var equals = IsEqual(added.ToArray(), clientTypeEntityTypeEntities.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                //foreach (var clientTypeEntity in db.ClientTypeEntities)
                //{
                //    db.ClientTypeEntities.Remove(clientTypeEntity);
                //}
                db.ClientTypeEntities.RemoveRange(db.ClientTypeEntities);

                db.SaveChanges();
            }
        }

        static IEnumerable<LClientTypeEntity> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.ClientTypeEntities.Select(ClientTypeMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LClientTypeEntity> Add()
        {
            var clientTypeEntityTypeEntities = GetLogicClientTypeEntitys().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicClientTypeEntity in clientTypeEntityTypeEntities)
                {
                    var clientTypeEntity = ClientTypeMapper.ToDb(logicClientTypeEntity);
                    db.ClientTypeEntities.Add(clientTypeEntity);
                }

                db.SaveChanges();
            }

            return clientTypeEntityTypeEntities;
        }

        static IEnumerable<LClientTypeEntity> GetLogicClientTypeEntitys()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                yield return new LClientTypeEntity
                {
                    Type = ClientType.Standart,
                    Price = 1,
                };

                yield return new LClientTypeEntity
                {
                    Type = ClientType.Regular,
                    Price = 2,
                };

                yield return new LClientTypeEntity
                {
                    Type = ClientType.Black,
                    Price = 3,
                };

                yield return new LClientTypeEntity
                {
                    Type = ClientType.Gray,
                    Price = 4,
                };

                yield return new LClientTypeEntity
                {
                    Type = ClientType.White,
                    Price = 5,
                };
            }
        }

        static void Print(IEnumerable<LClientTypeEntity> clientTypeEntityTypeEntities)
        {
            var cnt = 0;
            foreach (var clientTypeEntity in clientTypeEntityTypeEntities)
            {
                cnt++;
                Print(clientTypeEntity);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LClientTypeEntity clientTypeEntity)
        {
            Console.WriteLine($" - Type: {clientTypeEntity.Type})");
            Console.WriteLine($" - Price: {clientTypeEntity.Price})");

            Console.WriteLine();
        }

        static bool IsEqual(LClientTypeEntity[] e1, LClientTypeEntity[] e2)
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
