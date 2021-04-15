using System;
using TRPO.Parking.DataBase.EntityInterfaces;

namespace TRPO.Parking.DataBase.EnumEntities
{
    public class BaseEnumEntity<T> : IEnumEntity<T> 
        where T : Enum
    {
        public BaseEnumEntity() { }

        public BaseEnumEntity(T value)
        {
            Id = value;
            Title = value.ToString();
        }

        public T Id { get; set; }
        public string Title { get; set; }
    }
}
