using System;
using TRPO.Parking.DataBase.EnumEntities;

using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class EmployeeMapper
    {
        public static readonly Func<LE.Employee, DB.Employee> ToDb =
            employee => new DB.Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                EmployeementDate = employee.EmployeementDate,
                Salary = employee.Salary,
                TypeId = employee.Type,
                Type = new EmployeeTypeEntity(employee.Type)
            };

        public static readonly Func<DB.Employee, LE.Employee> ToLogic =
            employee => new LE.Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                EmployeementDate = employee.EmployeementDate,
                Salary = employee.Salary,
                Type = employee.TypeId
            };
    }
}
