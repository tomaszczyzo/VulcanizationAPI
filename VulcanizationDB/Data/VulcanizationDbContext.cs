using Microsoft.EntityFrameworkCore;
using VulcanizationAPI.Core.Entities;
using VulcanizationAPI.Core.Entities.Concrete;

namespace VulcanizationAPI.Infrastructure.Data
{
    public class VulcanizationDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\Local;Database=VulcanizationDb;Trusted_Connection=True";
        public DbSet<Vulcanization> Vulcanizations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

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
            modelBuilder.Entity<User>()
                .Property(r => r.Email)
                .IsRequired();
            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
