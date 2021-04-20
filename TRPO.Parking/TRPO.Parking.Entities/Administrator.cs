namespace TRPO.Parking.Entities
{
    public class Administrator
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
