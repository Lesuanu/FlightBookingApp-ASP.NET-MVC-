using FlightBookingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightBookingApp.Infrastructure
{
    public class FlightEntityTypeConfiguration : IEntityTypeConfiguration<FlightBooking>
    {
        public void Configure(EntityTypeBuilder<FlightBooking> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Destination)
                .IsRequired();

            builder.Property(x => x.Flight_Class)
               .HasConversion(x => x.ToString(),
                v => (FlightClass)Enum.Parse(typeof(FlightClass), v));

            builder.Property(x => x.Flight_Name)
               .HasConversion(x => x.ToString(),
                v => (FlightName)Enum.Parse(typeof(FlightName), v));

            builder.Property(x => x.Departure_Time)
                .IsRequired();

            builder.Property(x => x.Arrival_Time)
                .IsRequired();

            builder.Property(x => x.Date)
                .IsRequired();
        }
    }
}
