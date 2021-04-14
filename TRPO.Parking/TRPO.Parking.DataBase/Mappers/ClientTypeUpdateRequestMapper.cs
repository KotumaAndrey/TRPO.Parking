using System;
using TRPO.Parking.DataBase.EnumEntities;
using TRPO.Parking.Entities.Primitives;

using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class ClientTypeUpdateRequestMapper
    {
        public static readonly Func<LE.ClientTypeUpdateRequest, DB.ClientTypeUpdateRequest> ToDb =
            clientTypeUpdateRequest => new DB.ClientTypeUpdateRequest
            {
                Id = clientTypeUpdateRequest.Id,
                ClientId = clientTypeUpdateRequest.Client.Id,
                Client = ClientMapper.ToDb(clientTypeUpdateRequest.Client),
                OpenDate = clientTypeUpdateRequest.OpenDate,
                OldClientTypeId = clientTypeUpdateRequest.OldClientType,
                OldClientType = new ClientTypeEntity(clientTypeUpdateRequest.OldClientType,
                    ClientTypeExt.GetPrice(clientTypeUpdateRequest.OldClientType)),
                NewClientTypeId = clientTypeUpdateRequest.NewClientType,
                NewClientType = new ClientTypeEntity(clientTypeUpdateRequest.NewClientType,
                    ClientTypeExt.GetPrice(clientTypeUpdateRequest.NewClientType)),
                StatusId = clientTypeUpdateRequest.Status,
                Status = new ClientTypeUpdateRequestStatusEntity(clientTypeUpdateRequest.Status),
                AdministratorId = clientTypeUpdateRequest.Administrator.Id,
                Administrator = AdministratorMapper.ToDb(clientTypeUpdateRequest.Administrator),
                CloseDate = clientTypeUpdateRequest.CloseDate
            };

        public static readonly Func<DB.ClientTypeUpdateRequest, LE.ClientTypeUpdateRequest> ToLogic =
            clientTypeUpdateRequest => new LE.ClientTypeUpdateRequest
            {
                Id = clientTypeUpdateRequest.Id,
                Client = ClientMapper.ToLogic(clientTypeUpdateRequest.Client),
                OpenDate = clientTypeUpdateRequest.OpenDate,
                OldClientType = clientTypeUpdateRequest.OldClientTypeId,
                NewClientType = clientTypeUpdateRequest.NewClientTypeId,
                Status = clientTypeUpdateRequest.StatusId,
                Administrator = AdministratorMapper.ToLogic(clientTypeUpdateRequest.Administrator),
                CloseDate = clientTypeUpdateRequest.CloseDate
            };
    }
}
