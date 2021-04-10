using TRPO.Parking.DataBase.EntityInterfaces;

namespace TRPO.Parking.DataBase.Entities
{
    public class Floor : IEntityWithIntId
    {
        public int Id { get; set; }

        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
    }
}
