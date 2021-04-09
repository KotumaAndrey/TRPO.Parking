using EmployeeType = TRPO.Parking.DataBase.Primitives.EmployeeType;

namespace TRPO.Parking.DataBase.EnumEntities
{
    public class EmployeeTypeEntity : BaseEnumEntity<EmployeeType>
    {
        public EmployeeTypeEntity() : base() { }

        public EmployeeTypeEntity(EmployeeType value) : base(value) { }
    }
}
