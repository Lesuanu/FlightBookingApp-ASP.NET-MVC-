using FlightBookingApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingApp.Infrastructure
{
    public class FlightBookingContext : IdentityDbContext<FlightIdentityUser>
    {
        public FlightBookingContext(DbContextOptions<FlightBookingContext> options) : base(options)
        {
            
        }

        public DbSet<FlightBooking> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new FlightEntityTypeConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlightEntityTypeConfiguration).Assembly);
        }
    }
}
