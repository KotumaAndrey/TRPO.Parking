using System;

namespace TRPO.Parking.DataBase.EntityInterfaces
{
    public interface IEnumEntity<T> where T : Enum
    {
        T Id { get; }
    }
}
