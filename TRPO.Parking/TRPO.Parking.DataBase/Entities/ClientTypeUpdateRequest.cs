using System;
using TRPO.Parking.DataBase.EnumEntities;

namespace TRPO.Parking.DataBase.Entities
{
    public class ClientTypeUpdateRequest
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public DateTime OpenDate { get; set; }

        public int OldClientTypeId { get; set; }
        public virtual ClientTypeEntity OldClientType { get; set; }

        public int NewClientTypeId { get; set; }
        public virtual ClientTypeEntity NewClientType { get; set; }

        public int StatusId { get; set; }
        public virtual ClientTypeUpdateRequestStatusEntity Status { get; set; }
        
        public int? AdministratorId { get; set; }
        public virtual Administrator Administrator { get; set; }

        public DateTime? CloseDate { get; set; }
    }
}
