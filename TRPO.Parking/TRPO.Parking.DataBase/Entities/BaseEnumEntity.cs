using System;

namespace TRPO.Parking.DataBase.Entities
{
    public class BaseEnumEntity<T> where T : Enum
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
