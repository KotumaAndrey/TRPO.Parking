using System;
using TRPO.Parking.DataBase.EnumEntities;
using TRPO.Parking.Entities.Primitives;

using DB = TRPO.Parking.DataBase.Entities;
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
                Gender = new GenderEntity(client.Gender),
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Experience = client.Experience,
                ClientTypeId = client.ClientType,
                ClientType = new ClientTypeEntity(client.ClientType,
                    ClientTypeExt.GetPrice(client.ClientType)),
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
                ClientType = client.ClientTypeId,
                LatePaymentMinutesLeft = client.LatePaymentMinutesLeft,
                LatePaymentPriceMultiplier = client.LatePaymentPriceMultiplier
            };
    }
}
