using Microsoft.EntityFrameworkCore;
using SorveSoftApi.Data.Mapping;
using SorveSoftApi.Models;

namespace SorveSoftApi.Data
{
    public class SorveSoftDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=SorveSoftDb;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
        }
    }
}
