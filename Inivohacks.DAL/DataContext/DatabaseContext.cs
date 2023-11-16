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
        public DbSet<Batch> Batch { get; set; }
        public DbSet<BatchItem> BatchItem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Scan>().HasOne(e => e.User)
                .WithMany(u => u.Scans).HasForeignKey(e => e.UserID).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Scan>()
           .HasOne(e => e.Certificate)
            .WithMany().HasForeignKey(e => e.CertificationID)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TrackingCode>()
                .HasOne(e => e.Product)
                .WithMany(e => e.TrackingCodes).HasForeignKey(e=>e.ProductID).OnDelete(DeleteBehavior.Restrict); 

           builder.Entity<Certificate>()
                .HasOne(e => e.Product)
                .WithMany(e => e.Certificates).HasForeignKey(e => e.ProductID).OnDelete(DeleteBehavior.Restrict); ;
        }

    }
}
