using Gender = TRPO.Parking.Entities.Primitives.Gender;

namespace TRPO.Parking.DataBase.EnumEntities
{
    public class GenderEntity : BaseEnumEntity<Gender>
    {
        public GenderEntity(Gender? gender) : base() { }

        public GenderEntity(Gender value) : base(value) { }
    }
}
