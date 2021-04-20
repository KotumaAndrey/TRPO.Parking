using System;

namespace TRPO.Parking.Entities
{
    public class Accident
    {
        public int Id { get; set; }
        public DateTime AccidentDate { get; set; }
        public virtual Client CulpritClient { get; set; }
        public string Comment { get; set; }
    }
}
