using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VulcanizationAPI.Core.Entities;
using VulcanizationAPI.Core.Entities.Concrete;

namespace VulcanizationAPI.Infrastructure.Data
{
    public class VulcanizationDbContext : DbContext
    {
        //private string _connectionString = "Server=(localdb)\\Local;Database=VulcanizationDb;Trusted_Connection=True";
        public DbSet<Vulcanization> Vulcanizations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserVulcanization> UserVulcanizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserVulcanization>()
                .HasKey(uv => new { uv.UserId, uv.VulcanizationId });

            modelBuilder.Entity<UserVulcanization>()
                .HasOne(uv => uv.Vulcanization)
                .WithMany(v => v.UserVulcanizations)
                .HasForeignKey(uv => uv.VulcanizationId);

            modelBuilder.Entity<UserVulcanization>()
                .HasOne(uv => uv.User)
                .WithMany(u => u.UserVulcanizations)
                .HasForeignKey(uv => uv.UserId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
