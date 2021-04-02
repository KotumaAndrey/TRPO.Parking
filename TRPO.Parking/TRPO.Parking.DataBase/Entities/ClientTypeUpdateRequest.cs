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
        public ClientTypeEntity OldClientType { get; set; }

        public int NewClientTypeId { get; set; }
        public ClientTypeEntity NewClientType { get; set; }

        public int StatusId { get; set; }
        public ClientTypeUpdateRequestStatusEntity Status { get; set; }
        
        public int? AdministratorId { get; set; }
        public Administrator Administrator { get; set; }

        public DateTime? CloseDate { get; set; }
    }
}
