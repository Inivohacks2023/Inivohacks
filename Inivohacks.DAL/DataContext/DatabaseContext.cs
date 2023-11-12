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

            builder.Entity<Scan>()
            .HasOne(e => e.User)
             .WithMany().HasForeignKey(e=>e.UserID)
    .       OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Scan>()
           .HasOne(e => e.Certificate)
            .WithMany().HasForeignKey(e => e.CertificateID)
            .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
