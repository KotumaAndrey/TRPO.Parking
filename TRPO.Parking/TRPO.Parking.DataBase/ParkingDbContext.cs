using System;
using Microsoft.EntityFrameworkCore;
using TRPO.Parking.DataBase.Entities;

namespace TRPO.Parking.DataBase
{
    public class ParkingDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Parking.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenderEntity>()
                .ToTable("GenderEntity");

            modelBuilder.Entity<GenderEntity>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<ClientTypeEntity>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<AccidentMember>().HasKey(k => new { k.AccidentId, k.ClientId });
            modelBuilder.Entity<ActiveRentalParkingSpaces>().HasKey(k => new { k.ActiveRentalId, k.ParkingSpaceId });
            modelBuilder.Entity<ClosedRentalParkingSpaces>().HasKey(k => new { k.ClosedRentalId, k.ParkingSpaceId });

            base.OnModelCreating(modelBuilder);
        }

        public ParkingDbContext()
        {
            Database.EnsureCreated();

            GenderEntities.AddEnumValues<GenderEntity, Primitives.Gender>(value => new GenderEntity(value));
            SaveChanges();
        }

        #region Entities

        public DbSet<ActiveRental> ActiveRentals { get; set; }
        public DbSet<ActiveRentalParkingSpaces> ActiveRentalParkingSpaces { get; set; }
        public DbSet<ActiveRentalRenewal> ActiveRentalRenewals { get; set; }

        public DbSet<ClosedRental> ClosedRentals { get; set; }
        public DbSet<ClosedRentalParkingSpaces> ClosedRentalParkingSpaces { get; set; }
        public DbSet<ClosedRentalRenewal> ClosedRentalRenewals { get; set; }

        public DbSet<RentalRenewalType> RentalRenewalTypes { get; set; }

        public DbSet<LatePayment> LatePayments { get; set; }
        public DbSet<LatePaymentType> LatePaymentTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTypeEntity> EmployeeTypeEntities { get; set; }
        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<GenderEntity> GenderEntities { get; set; }
        public DbSet<ClientTypeEntity> ClientTypeEntities { get; set; }
        public DbSet<ClientTypeUpdateRequest> ClientTypeUpdateRequests { get; set; }
        public DbSet<ClientTypeUpdateRequestStatusEntity> ClientTypeUpdateRequestStatusEntities { get; set; }

        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<ParkingSpaceStatusEntity> ParkingSpaceStatusEntities { get; set; }
        public DbSet<Floor> Floors { get; set; }

        public DbSet<Accident> Accidents { get; set; }
        public DbSet<AccidentMember> AccidentMembers { get; set; }

        #endregion
    }
}