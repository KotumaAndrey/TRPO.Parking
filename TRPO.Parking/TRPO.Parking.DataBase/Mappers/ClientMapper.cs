using System;
using TRPO.Parking.DataBase.EnumEntities;
using TRPO.Parking.DataBase.Mappers.Utilities;
using TRPO.Parking.Entities.Primitives;

using DB = TRPO.Parking.DataBase.Entities;
using DBEE = TRPO.Parking.DataBase.EnumEntities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class ClientMapper
    {
        public static readonly Func<LE.Client, DB.Client> ToDb =
            client => new DB.Client
            {
                Id = client.Id,
                Password = client.Password,
                Name = client.Name,
                Age = client.Age,
                GenderId = client.Gender,
                //Gender = client.Gender is null ? null : new GenderEntity(client.Gender.Value),
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Experience = client.Experience,
                ClientTypeId = client.ClientType.Type,
                //ClientType = ClientTypeMapper.ToDb(client.ClientType),
                LatePaymentMinutesLeft = client.LatePaymentMinutesLeft,
                LatePaymentPriceMultiplier = client.LatePaymentPriceMultiplier
            };

        public static readonly Func<DB.Client, LE.Client> ToLogic =
            client => new LE.Client
            {
                Id = client.Id,
                Password = client.Password,
                Name = client.Name,
                Age = client.Age,
                Gender = client.GenderId,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Experience = client.Experience,
                ClientType = ClientTypeMapper.ToLogic(GetEntityFromDb.GetWithEnum<LE.ClientTypeEntity, DBEE.ClientTypeEntity, ClientType>(client.ClientTypeId)),
                //client.ClientType is null ? null : ClientTypeMapper.ToLogic(client.ClientType),
                LatePaymentMinutesLeft = client.LatePaymentMinutesLeft,
                LatePaymentPriceMultiplier = client.LatePaymentPriceMultiplier
            };
    }
}
