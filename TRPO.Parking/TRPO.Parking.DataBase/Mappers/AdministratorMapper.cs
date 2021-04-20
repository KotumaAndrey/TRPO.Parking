using System;

using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class AdministratorMapper
    {
        public static readonly Func<LE.Administrator, DB.Administrator> ToDb =
            administrator => new DB.Administrator
        {
                Id = administrator.Id,
                Login = administrator.Login,
                Password = administrator.Password,
                EmployeeId = administrator.Employee.Id,
                //Employee = EmployeeMapper.ToDb(administrator.Employee)
        };

        public static readonly Func<DB.Administrator, LE.Administrator> ToLogic =
            administrator => new LE.Administrator
            {
                Id = administrator.Id,
                Login = administrator.Login,
                Password = administrator.Password,
                Employee = EmployeeMapper.ToLogic(administrator.Employee)
            };
    }
}
