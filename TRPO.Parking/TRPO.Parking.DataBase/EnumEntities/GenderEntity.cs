using Gender = TRPO.Parking.DataBase.Primitives.Gender;

namespace TRPO.Parking.DataBase.EnumEntities
{
    public class GenderEntity : BaseEnumEntity<Gender>
    {
        public GenderEntity() : base() { }

        public GenderEntity(Gender value) : base(value) { }
    }
}
