using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain.Models;

namespace Taxi.API.Data
{
    public class TaxiContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Order> Orders { get; set; }

        public TaxiContext(DbContextOptions<TaxiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>(e =>
            {
                e.Property(c => c.StartPrice).HasColumnType("decimal(10,2)");
                e.Property(c => c.PricePerKm).HasColumnType("decimal(10,2)");
            });
            
            builder.Entity<Order>(e => e.Property(o => o.TotalPrice).HasColumnType("decimal(10,2)"));
            
            DataSeeder.Seed(builder);
        }
    }
}
