namespace TRPO.Parking.DataBase.Entities
{
    public class AccidentMember
    {
        public int AccidentId { get; set; }
        public virtual Accident Accident { get; set; }
        
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
