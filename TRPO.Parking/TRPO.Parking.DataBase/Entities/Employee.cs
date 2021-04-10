using System;
using TRPO.Parking.DataBase.EnumEntities;
using TRPO.Parking.Entities.Primitives;

namespace TRPO.Parking.DataBase.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EmployeementDate { get; set; }
        public int Salary { get; set; }

        public ClientType TypeId { get; set; }
        public virtual EmployeeTypeEntity Type { get; set; }
    }
}
