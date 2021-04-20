using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Entities.Primitives;
using TRPO.Parking.Utilitas.Pathfinder;

using LClient = TRPO.Parking.Entities.Client;
using DbClient = TRPO.Parking.DataBase.Entities.Client;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    static class ClientTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.WriteLine("Client:");

            Clear();
            var clients = GetAll();
            if (print) Print(clients);
            var added = Add();
            clients = GetAll();
            if (print) Print(clients);
            Console.WriteLine($"- {IsEqual(added.ToArray(), clients.ToArray())}");
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var client in db.Clients)
                {
                    db.Clients.Remove(client);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LClient> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.Clients.Select(ClientMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LClient> Add()
        {
            var clients = GetLogicClients().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicClient in clients)
                {
                    var client = ClientMapper.ToDb(logicClient);
                    db.Clients.Add(client);
                }

                db.SaveChanges();
            }

            return clients;
        }

        static IEnumerable<LClient> GetLogicClients()
        {
            int cnt = 1;

            yield return new LClient
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
            };

            yield return new LClient
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
            };

            cnt++;
            yield return new LClient
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
            };

            cnt++;
            yield return new LClient
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
                Age = 8,
            };

            cnt++;
            yield return new LClient
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
                ClientType = Entities.Primitives.ClientType.Black.ToEntity(),
            };

            cnt++;
            yield return new LClient
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
                Email = "aaaa",
            };

            cnt++;
            yield return new LClient
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
                Experience = 8,
            };

            cnt++;
            yield return new LClient
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
                Gender = Gender.Male,
            };

            cnt++;
            yield return new LClient
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
                LatePaymentMinutesLeft = 666,
                LatePaymentPriceMultiplier = 999999
            };
        }

        static void Print(IEnumerable<LClient> clients)
        {
            var cnt = 0;
            foreach (var client in clients)
            {
                cnt++;
                Print(client);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LClient client)
        {
            Console.WriteLine($"{client.Id}) {client.Name.ToNullStr()}");

            Console.WriteLine($" - PhoneNumber: {client.PhoneNumber.ToNullStr()}");
            Console.WriteLine($" - Password: {client.Password.ToNullStr()}");

            Console.WriteLine($" - Gender: {client.Gender.ToNullStr()}");
            Console.WriteLine($" - Age: {client.Age.ToNullStr()}");
            Console.WriteLine($" - Email: {client.Email.ToNullStr()}");
            Console.WriteLine($" - Experience: {client.Experience.ToNullStr()}");
            Console.WriteLine($" - LatePaymentMinutesLeft: {client.LatePaymentMinutesLeft}");
            Console.WriteLine($" - LatePaymentPriceMultiplier: {client.LatePaymentPriceMultiplier}");

            Console.WriteLine($"- Type: {client.ClientType.Type}, {client.ClientType.Price}");

            Console.WriteLine();
        }

        static bool IsEqual(LClient[] c1, LClient[] c2)
        {
            if (c1.Length != c2.Length) return false;

            for (int i = 0; i < c1.Length; i++)
            {
                if (!TestExt.IsEqual(c1[i], c2[i])) return false;
            }

            return true;
        }
    }
}
