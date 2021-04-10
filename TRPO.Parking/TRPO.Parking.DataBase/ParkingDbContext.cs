using System;
using Microsoft.EntityFrameworkCore;
using TRPO.Parking.DataBase.Entities;
using TRPO.Parking.DataBase.EnumEntities;
using TRPO.Parking.Entities.Primitives;
using TRPO.Parking.Utilitas.Pathfinder;

namespace TRPO.Parking.DataBase
{
    public class ParkingDbContext : DbContext
    {
        private IPathfinder _pathfinder;

        public ParkingDbContext(IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;

            var created = Database.EnsureCreated();
            //if(created)
            //{
            InitEnumTables();
            //}
        }

        #region Init
        public void InitEnumTables()
        {
            ClientTypeEntities.AddEnumValues<ClientTypeEntity, ClientType>(value =>
            {
                var priceMultipler = value.GetPriceMultipler();
                var entity = new ClientTypeEntity(value, priceMultipler);
                return entity;
            });

            ClientTypeUpdateRequestStatusEntities.AddEnumValues<ClientTypeUpdateRequestStatusEntity, ClientTypeUpdateRequestStatus>(value => new ClientTypeUpdateRequestStatusEntity(value));

            EmployeeTypeEntities.AddEnumValues<EmployeeTypeEntity, EmployeeType>(value => new EmployeeTypeEntity(value));

            GenderEntities.AddEnumValues<GenderEntity, Gender>(value => new GenderEntity(value));

            ParkingSpaceStatusEntities.AddEnumValues<ParkingSpaceStatusEntity, ParkingSpaceStatus>(value => new ParkingSpaceStatusEntity(value));

            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var fileName = "Parking.db";
            var path = _pathfinder.GetPath(fileName);
            var connectionString = $"Filename={path}";
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientTypeEntity>()
                .ToTable("ClientTypes")
                .HasKey(e => e.Id);

            modelBuilder.Entity<ClientTypeUpdateRequestStatusEntity>()
                .ToTable("ClientTypeUpdateRequestStatuses")
                .HasKey(e => e.Id);

            modelBuilder.Entity<EmployeeTypeEntity>()
                .ToTable("EmployeeTypes")
                .HasKey(e => e.Id);

            modelBuilder.Entity<GenderEntity>()
                .ToTable("Genders")
                .HasKey(e => e.Id);

            modelBuilder.Entity<ParkingSpaceStatusEntity>()
                .ToTable("ParkingSpaceStatuses")
                .HasKey(e => e.Id);

            modelBuilder.Entity<AccidentMember>()
                .HasKey(k => new { k.AccidentId, k.ClientId });

            modelBuilder.Entity<ActiveRentalParkingSpaces>()
                .HasKey(k => new { k.ActiveRentalId, k.ParkingSpaceId });

            modelBuilder.Entity<ClosedRentalParkingSpaces>()
                .HasKey(k => new { k.ClosedRentalId, k.ParkingSpaceId });

            base.OnModelCreating(modelBuilder);
        }
        #endregion

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