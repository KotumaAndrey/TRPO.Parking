using System;
using TRPO.Parking.Entities.Primitives;

namespace TRPO.Parking.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EmployeementDate { get; set; }
        public int Salary { get; set; }
        public virtual EmployeeType Type { get; set; }
    }
}
