using System;
using TRPO.Parking.DataBase.EntityInterfaces;

namespace TRPO.Parking.DataBase.Entities
{
    public class Accident : IEntityWithIntId
    {
        public int Id { get; set; }

        public DateTime AccidentDate { get; set; }

        public int CulpritClientId { get; set; }
        public virtual Client CulpritClient { get; set; }

        public string Comment { get; set; }
    }
}
