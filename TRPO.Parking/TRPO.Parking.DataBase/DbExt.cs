using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TRPO.Parking.DataBase.Entities;

namespace TRPO.Parking.DataBase
{
    internal static class DbExt
    {
        public static void AddEnumValues<T, TEnum>(this DbSet<T> dbSet, Func<TEnum, T> converter)
            where T : BaseEnumEntity<TEnum>
            where TEnum : Enum
        {
            var values = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(converter)
                .ToArray();

            dbSet.AddOrUpdateEnumEntityRange<T, TEnum>(values);
        }

        public static void AddOrUpdateEnumEntityRange<T, TEnum>(this DbSet<T> dbSet, IEnumerable<T> data)
            where T : BaseEnumEntity<TEnum>
            where TEnum : Enum
        {
            foreach (var value in data)
            {
                dbSet.AddOrUpdateEnumEntity<T, TEnum>(value);
            }
        }

        public static void AddOrUpdateEnumEntity<T, TEnum>(this DbSet<T> dbSet, T data)
            where T : BaseEnumEntity<TEnum>
            where TEnum : Enum
        {
            var exist = dbSet.AsNoTracking()
                .Any(value => value.Id.Equals(data.Id));
            if (exist)
            {
                dbSet.Update(data);
            }
            else
            {
                dbSet.Add(data);
            }
        }
    }
}
