using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Entities.Primitives;
using TRPO.Parking.Utilitas.Pathfinder;

using LClientTypeUpdateRequest = TRPO.Parking.Entities.ClientTypeUpdateRequest;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class ClientTypeUpdateRequestTypeUpdateRequestTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ClientTypeUpdateRequest:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var clientTypeUpdateRequests = GetAll();
            if (print) Print(clientTypeUpdateRequests);
            var added = Add();
            clientTypeUpdateRequests = GetAll();
            if (print) Print(clientTypeUpdateRequests);

            var equals = IsEqual(added.ToArray(), clientTypeUpdateRequests.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var clientTypeUpdateRequest in db.ClientTypeUpdateRequests)
                {
                    db.ClientTypeUpdateRequests.Remove(clientTypeUpdateRequest);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LClientTypeUpdateRequest> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.ClientTypeUpdateRequests.Select(ClientTypeUpdateRequestMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LClientTypeUpdateRequest> Add()
        {
            var clientTypeUpdateRequests = GetLogicClientTypeUpdateRequests().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicClientTypeUpdateRequest in clientTypeUpdateRequests)
                {
                    var clientTypeUpdateRequest = ClientTypeUpdateRequestMapper.ToDb(logicClientTypeUpdateRequest);
                    db.ClientTypeUpdateRequests.Add(clientTypeUpdateRequest);
                }

                db.SaveChanges();
            }

            return clientTypeUpdateRequests;
        }

        static IEnumerable<LClientTypeUpdateRequest> GetLogicClientTypeUpdateRequests()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                var clients = db.Clients.AsNoTracking().ToArray();
                var administrators = db.Administrators.AsNoTracking().ToArray();

                yield return new LClientTypeUpdateRequest
                {
                    Client = ClientMapper.ToLogic(clients.FirstOrDefault()),
                    OpenDate = DateTime.Now,
                    OldClientType = ClientType.Standart,
                    NewClientType = ClientType.Regular,
                    Status = ClientTypeUpdateRequestStatus.Active,
                    Administrator = AdministratorMapper.ToLogic(administrators.FirstOrDefault()),
                    CloseDate = null,
                };

                yield return new LClientTypeUpdateRequest
                {
                    Client = ClientMapper.ToLogic(clients.ElementAt(3)),
                    OpenDate = DateTime.Now,
                    OldClientType = ClientType.Black,
                    NewClientType = ClientType.White,
                    Status = ClientTypeUpdateRequestStatus.Accepted,
                    Administrator = AdministratorMapper.ToLogic(administrators.FirstOrDefault()),
                    CloseDate = DateTime.Now,
                };

                yield return new LClientTypeUpdateRequest
                {
                    Client = ClientMapper.ToLogic(clients.LastOrDefault()),
                    OpenDate = DateTime.Now,
                    OldClientType = ClientType.Gray,
                    NewClientType = ClientType.White,
                    Status = ClientTypeUpdateRequestStatus.Rejected,
                    Administrator = AdministratorMapper.ToLogic(administrators.FirstOrDefault()),
                    CloseDate = DateTime.Now,
                };
            }
        }

        static void Print(IEnumerable<LClientTypeUpdateRequest> clientTypeUpdateRequests)
        {
            var cnt = 0;
            foreach (var clientTypeUpdateRequest in clientTypeUpdateRequests)
            {
                cnt++;
                Print(clientTypeUpdateRequest);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LClientTypeUpdateRequest clientTypeUpdateRequest)
        {
            Console.WriteLine($"{clientTypeUpdateRequest.Id})");

            Console.WriteLine($" - Client.Id: {clientTypeUpdateRequest.Client.Id}");
            Console.WriteLine($" - OpenDate: {clientTypeUpdateRequest.OpenDate}");

            Console.WriteLine($" - OldClientType: {clientTypeUpdateRequest.OldClientType}");
            Console.WriteLine($" - NewClientType: {clientTypeUpdateRequest.NewClientType}");

            Console.WriteLine($" - Status: {clientTypeUpdateRequest.Status}");
            Console.WriteLine($" - Administrator.Id: {clientTypeUpdateRequest.Administrator.Id}");
            Console.WriteLine($" - CloseDate: {clientTypeUpdateRequest.CloseDate}");

            Console.WriteLine();
        }

        static bool IsEqual(LClientTypeUpdateRequest[] e1, LClientTypeUpdateRequest[] e2)
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
