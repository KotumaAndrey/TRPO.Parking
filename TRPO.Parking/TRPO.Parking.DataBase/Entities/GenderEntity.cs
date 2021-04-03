namespace TRPO.Parking.DataBase.Entities
{
    public class GenderEntity : BaseEnumEntity<Primitives.Gender>
    {
        public GenderEntity() : base() { }

        public GenderEntity(Primitives.Gender value) : base(value) { }
    }
}
