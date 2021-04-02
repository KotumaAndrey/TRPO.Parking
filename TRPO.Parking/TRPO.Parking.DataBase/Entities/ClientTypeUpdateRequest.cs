using System;

namespace TRPO.Parking.DataBase.Entities
{
    public class ClientTypeUpdateRequest
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public DateTime OpenDate { get; set; }

        public int OldClientTypeId { get; set; }
        public Primitives.ClientType OldClientType { get; set; }

        public int NewClientTypeId { get; set; }
        public Primitives.ClientType NewClientType { get; set; }

        public int StatusId { get; set; }
        public Primitives.ClientTypeUpdateRequestStatus Status { get; set; }
        
        public int? AdministratorId { get; set; }
        public Administrator Administrator { get; set; }

        public DateTime? CloseDate { get; set; }
    }
}
