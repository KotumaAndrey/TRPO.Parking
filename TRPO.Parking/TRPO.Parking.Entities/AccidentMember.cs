namespace TRPO.Parking.Entities
{
    public class AccidentMember
    {
        public virtual Accident Accident { get; set; }
        public virtual Client Client { get; set; }
    }
}
