using System;

using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class AccidentMemberMapper
    {
        public static readonly Func<LE.AccidentMember, DB.AccidentMember> ToDb =
            accidentMember => new DB.AccidentMember
            {
                AccidentId = accidentMember.Accident.Id,
                //Accident = AccidentMapper.ToDb(accidentMember.Accident),
                ClientId = accidentMember.Client.Id,
                //Client = ClientMapper.ToDb(accidentMember.Client)
            };

        public static readonly Func<DB.AccidentMember, LE.AccidentMember> ToLogic =
            accidentMember => new LE.AccidentMember
            {
                Accident = AccidentMapper.ToLogic(accidentMember.Accident),
                Client = ClientMapper.ToLogic(accidentMember.Client),
            };
    }
}
