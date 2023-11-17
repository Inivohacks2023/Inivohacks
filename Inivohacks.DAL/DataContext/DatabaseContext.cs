using Inivohacks.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Reflection.Emit;

namespace Inivohacks.DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Manufacturer> Manufacturers { get;set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<Scan> Scans { get; set; }
        public DbSet<TrackingCode> TrackingCodes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<CertPermission> CertPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Scan>().HasOne(e => e.User)
                .WithMany(u => u.Scans).HasForeignKey(e => e.UserID).OnDelete(DeleteBehavior.Restrict);

             builder.Entity<Scan>()
                .HasOne(s => s.TrackingCode)
                .WithMany(tc => tc.Scans)
                .HasForeignKey(s => s.TrackingCodeID)
                .OnDelete(DeleteBehavior.Restrict);

            //Create Dummy Data 
            SeedDatabase(builder);
            builder.Entity<TrackingCode>()
                .HasOne(e => e.Product)
                .WithMany(e => e.TrackingCodes).HasForeignKey(e=>e.ProductID).OnDelete(DeleteBehavior.Restrict); 

           builder.Entity<Certificate>()
                .HasOne(e => e.Product)
                .WithMany(e => e.Certificates).HasForeignKey(e => e.ProductID).OnDelete(DeleteBehavior.Restrict); ;
        }

        private void SeedDatabase(ModelBuilder builder)
        {
            builder.Entity<Manufacturer>()
                .HasData(new Manufacturer
                {
                    //ID = 1
                    ManufacturerID = 1,
                    Name = "Walter White Pharmaceuticals",
                    NotifySMS = "+1 1234567890",
                    NotifyEmail = "walter.white@example.com",
                    Address = "308 Negro Aroya Lane, Alberquerqe, New Mexico",
                });

            builder.Entity<User>()
                .HasData(new User
                {
                    UserID = 1,
                    FirstName = "Jesse",
                    LastName = "Pinkman",
                    LoginDisabled = false,
                    ManufacturerID = 1,
                    Password = "123",
                    Username = "jesse"
                }); ;
        }
    }
}
