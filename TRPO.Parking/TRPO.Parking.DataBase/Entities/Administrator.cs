using TRPO.Parking.DataBase.EntityInterfaces;

namespace TRPO.Parking.DataBase.Entities
{
    public class Administrator : IEntityWithIntId
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
