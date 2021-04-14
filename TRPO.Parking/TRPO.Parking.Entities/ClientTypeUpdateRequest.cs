using System;
using TRPO.Parking.Entities.Primitives;

namespace TRPO.Parking.Entities
{
    public class ClientTypeUpdateRequest
    {
        public int Id { get; set; }
        public virtual Client Client { get; set; }
        public DateTime OpenDate { get; set; }
        public virtual ClientType OldClientType { get; set; }
        public virtual ClientType NewClientType { get; set; }
        public virtual ClientTypeUpdateRequestStatus Status { get; set; }
        public virtual Administrator Administrator { get; set; }
        public DateTime? CloseDate { get; set; }
    }
}
