using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulcanizationAPI.Entities
{
    public class VulcanizationDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\Local;Database=VulcanizationDb;Trusted_Connection=True";
        public DbSet<Vulcanization> Vulcanizations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vulcanization>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(35);
            modelBuilder.Entity<Address>()
                .Property(r => r.City)
                .IsRequired()
                .HasMaxLength(45);
            modelBuilder.Entity<Service>()
                .Property(r => r.Price)
                .HasPrecision(9, 2);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
