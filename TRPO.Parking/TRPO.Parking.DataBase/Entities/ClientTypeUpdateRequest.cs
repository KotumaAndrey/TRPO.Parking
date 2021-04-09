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

        public Primitives.ClientType OldClientTypeId { get; set; }
        public virtual ClientTypeEntity OldClientType { get; set; }

        public Primitives.ClientType NewClientTypeId { get; set; }
        public virtual ClientTypeEntity NewClientType { get; set; }

        public Primitives.ClientTypeUpdateRequestStatus StatusId { get; set; }
        public virtual ClientTypeUpdateRequestStatusEntity Status { get; set; }
        
        public int? AdministratorId { get; set; }
        public virtual Administrator Administrator { get; set; }

        public DateTime? CloseDate { get; set; }
    }
}
