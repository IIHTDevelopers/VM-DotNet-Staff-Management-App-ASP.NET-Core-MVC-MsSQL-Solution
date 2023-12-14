using Microsoft.EntityFrameworkCore;
using StaffManagementApp.Models;

namespace StaffManagementApp.DAL
{
    public class StaffDbContext : DbContext
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options)
        {
        }

        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // You can configure additional settings for your entities here
            // Example: modelBuilder.Entity<Staff>().Property(v => v.FirstName).IsRequired();
        }
    }
}