﻿using System;

namespace TRPO.Parking.DataBase.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EmployeementDate { get; set; }
        public int Salary { get; set; }

        public int TypeId { get; set; }
        public EmployeeTypeEntity Type { get; set; }
    }
}
