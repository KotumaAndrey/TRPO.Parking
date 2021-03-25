namespace TRPO.Parking.DataBase.Entities
{
    public class Administrator
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
