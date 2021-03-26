using System;

namespace TRPO.Parking.DataBase.Entities
{
    public class ClientTypeUpdateRequest
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime OpenDate { get; set; }
        public Primitives.ClientType OldClientTypeId { get; set; }
        public Primitives.ClientType NewClientTypeId { get; set; }
        public Primitives.ClientTypeUpdateRequestStatus StatusId { get; set; }
        public int? AdministratorId { get; set; }
        public DateTime? CloseDate { get; set; }
    }
}
