using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Entities;
using TRPO.Parking.Entities.Primitives;
using TRPO.Parking.Utilitas.Pathfinder;

namespace TRPO.Parking.ConsoleApp
{
    class Program
    {
        static IPathfinder pathfinder = Dependencies.DependencyResolver.Container.Resolve<IPathfinder>();
        static void Main(string[] args)
        {
            Clear();
            var clients = GetAll();
            Print(clients);
            Add();
            clients = GetAll();
            Print(clients);

            // --- --- ---
            Console.WriteLine("\nend");
            Console.ReadKey();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(pathfinder))
            {
                foreach (var client in db.Clients)
                {
                    db.Clients.Remove(client);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<Entities.Client> GetAll()
        {
            using (var db = new ParkingDbContext(pathfinder))
            {
                return db.Clients.Select(ClientMapper.ToLogic).ToArray();
            }
        }

        static void Add()
        {
            var clients = GetLogicClients().ToArray();
            using (var db = new ParkingDbContext(pathfinder))
            {
                foreach (var logicClient in clients)
                {
                    var client = ClientMapper.ToDb(logicClient);
                    db.Clients.Add(client);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<Entities.Client> GetLogicClients()
        {
            int cnt = 1;

            yield return new Client
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
            };

            yield return new Client
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
            };

            cnt++;
            yield return new Client
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
            };

            cnt++;
            yield return new Client
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
                Age = 8,
            };

            cnt++;
            yield return new Client
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
                ClientType = Entities.Primitives.ClientType.Black.ToEntity(),
            };

            cnt++;
            yield return new Client
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
                Email = "aaaa",
            };

            cnt++;
            yield return new Client
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
                Experience = 8,
            };

            cnt++;
            yield return new Client
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
                Gender = Gender.Male,
            };

            cnt++;
            yield return new Client
            {
                Name = cnt.ToString(),
                PhoneNumber = cnt.ToString(),
                Password = cnt.ToString(),
                LatePaymentMinutesLeft = 666,
                LatePaymentPriceMultiplier = 999999
            };
        }

        static void Print(IEnumerable<Entities.Client> clients)
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

        static void Print(Entities.Client client)
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

            Print(client.ClientType);

            Console.WriteLine();
        }

        static void Print(Entities.ClientTypeEntity type)
        {
            Console.WriteLine($"- Type: {type.Type}, {type.Price}");
        }
    }

    static class ProgramExt
    {
        public static string ToNullStr<T>(this T obj) where T : class 
            => obj?.ToString() ?? "<null>";

        public static string ToNullStr<T>(this T? obj) where T : struct
            => obj?.ToString() ?? "<null>";
    }
}
