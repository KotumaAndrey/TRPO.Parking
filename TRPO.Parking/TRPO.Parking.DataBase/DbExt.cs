using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TRPO.Parking.DataBase.EntityInterfaces;
using TRPO.Parking.DataBase.EnumEntities;

namespace TRPO.Parking.DataBase
{
    internal static class DbExt
    {
        #region Enum
        public static void AddOrUpdateEnumValues<T, TEnum>(this DbSet<T> dbSet, Func<TEnum, T> converter)
            where T : class, IEnumEntity<TEnum>
            where TEnum : Enum
        {
            var values = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(converter)
                .ToArray();

            dbSet.AddOrUpdateEnumEntityRange<T, TEnum>(values);
        }

        public static void AddOrUpdateEnumEntityRange<T, TEnum>(this DbSet<T> dbSet, IEnumerable<T> data)
            where T : class, IEnumEntity<TEnum>
            where TEnum : Enum
        {
            foreach (var value in data)
            {
                dbSet.AddOrUpdateEnumEntity<T, TEnum>(value);
            }
        }

        public static void AddOrUpdateEnumEntity<T, TEnum>(this DbSet<T> dbSet, T data)
            where T : class, IEnumEntity<TEnum>
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
        #endregion

        #region Values
        public static void AddOrUpdateOuterValues<DbType, OuterType>(this DbSet<DbType> dbSet, IEnumerable<OuterType> inputData, Func<OuterType, DbType> converter)
            where DbType : class, IEntityWithIntId
        {
            foreach (var value in inputData)
            {
                dbSet.AddOrUpdateOuterValue(value, converter);
            }
        }

        public static void AddOrUpdateOuterValue<DbType, OuterType>(this DbSet<DbType> dbSet, OuterType inputData, Func<OuterType, DbType> converter)
            where DbType : class, IEntityWithIntId
        {
            var data = converter(inputData);
            dbSet.AddOrUpdateValue(data);
        }

        public static void AddOrUpdateValue<DbType>(this DbSet<DbType> dbSet, DbType data)
            where DbType : class, IEntityWithIntId
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
        #endregion
    }
}
