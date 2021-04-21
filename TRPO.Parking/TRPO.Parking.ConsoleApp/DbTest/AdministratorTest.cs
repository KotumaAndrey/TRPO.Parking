using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Entities.Primitives;
using TRPO.Parking.Utilitas.Pathfinder;

using LAdministrator = TRPO.Parking.Entities.Administrator;


namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class AdministratorTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Administrator:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var administrators = GetAll();
            if (print) Print(administrators);
            var added = Add();
            administrators = GetAll();
            if (print) Print(administrators);

            var equals = IsEqual(added.ToArray(), administrators.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var administrator in db.Administrators)
                {
                    db.Administrators.Remove(administrator);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LAdministrator> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.Administrators.Select(AdministratorMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LAdministrator> Add()
        {
            var administrators = GetLogicAdministrators().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicAdministrator in administrators)
                {
                    var administrator = AdministratorMapper.ToDb(logicAdministrator);
                    db.Administrators.Add(administrator);
                }

                db.SaveChanges();
            }

            return administrators;
        }

        static IEnumerable<LAdministrator> GetLogicAdministrators()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                yield return new LAdministrator
                {
                    Login = "adm",
                    Password = "1111",
                    Employee = EmployeeMapper.ToLogic(db.Employees.AsNoTracking().FirstOrDefault())
                };
            }
        }

        static void Print(IEnumerable<LAdministrator> administrators)
        {
            var cnt = 0;
            foreach (var administrator in administrators)
            {
                cnt++;
                Print(administrator);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LAdministrator administrator)
        {
            Console.WriteLine($"{administrator.Id})");

            Console.WriteLine($" - Login: {administrator.Login}");
            Console.WriteLine($" - Password: {administrator.Password.ToNullStr()}");
            Console.WriteLine($" - Employee.Id: {administrator.Employee.Id}");

            Console.WriteLine();
        }

        static bool IsEqual(LAdministrator[] e1, LAdministrator[] e2)
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
