using System;
using System.Collections.Generic;
using System.Linq;
using TRPO.Parking.DataBase;
using TRPO.Parking.DataBase.Mappers;
using TRPO.Parking.Entities.Primitives;
using TRPO.Parking.Utilitas.Pathfinder;

using LEmployee = TRPO.Parking.Entities.Employee;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    public static class EmployeeTest
    {
        private static IPathfinder _pathfinder;
        public static void Test(bool print, IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Employee:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Clear();
            var employees = GetAll();
            if (print) Print(employees);
            var added = Add();
            employees = GetAll();
            if (print) Print(employees);

            var equals = IsEqual(added.ToArray(), employees.ToArray());

            if (equals) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine($"- {equals}");
            Console.WriteLine();
        }

        static void Clear()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var employee in db.Employees)
                {
                    db.Employees.Remove(employee);
                }

                db.SaveChanges();
            }
        }

        static IEnumerable<LEmployee> GetAll()
        {
            using (var db = new ParkingDbContext(_pathfinder))
            {
                return db.Employees.Select(EmployeeMapper.ToLogic).ToArray();
            }
        }

        static IEnumerable<LEmployee> Add()
        {
            var employees = GetLogicEmployees().ToArray();
            using (var db = new ParkingDbContext(_pathfinder))
            {
                foreach (var logicEmployee in employees)
                {
                    var employee = EmployeeMapper.ToDb(logicEmployee);
                    db.Employees.Add(employee);
                }

                db.SaveChanges();
            }

            return employees;
        }

        static IEnumerable<LEmployee> GetLogicEmployees()
        {
            yield return new LEmployee
            {
                Name = "Admin",
                EmployeementDate = DateTime.Now,
                Salary = 1000,
                Type = EmployeeType.Administrator,
            };
        }

        static void Print(IEnumerable<LEmployee> employees)
        {
            var cnt = 0;
            foreach (var employee in employees)
            {
                cnt++;
                Print(employee);
            }

            if (cnt < 1)
            {
                Console.WriteLine("<No results>");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Print(LEmployee employee)
        {
            Console.WriteLine($"{employee.Id}) {employee.Name.ToNullStr()}");

            Console.WriteLine($" - EmployeementDate: {employee.EmployeementDate}");
            Console.WriteLine($" - Salary: {employee.Salary}");
            Console.WriteLine($" - Type: {employee.Type}");

            Console.WriteLine();
        }

        static bool IsEqual(LEmployee[] e1, LEmployee[] e2)
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
