namespace TRPO.Parking.DataBase.Entities
{
    public class AccidentMember
    {
        public int AccidentId { get; set; }
        public Accident Accident { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
