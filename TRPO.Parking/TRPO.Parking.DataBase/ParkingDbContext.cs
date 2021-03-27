using Microsoft.EntityFrameworkCore;
using TRPO.Parking.DataBase.Entities;

namespace TRPO.Parking.DataBase
{
    public class ParkingDbContext : DbContext
    {
         public virtual DbSet<GenderEntity> GenderEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Filename=Parking.db");
        }

    }
}