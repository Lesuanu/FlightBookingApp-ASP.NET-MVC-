using FlightBookingApp.Infrastructure;
using FlightBookingApp.Interface;
using FlightBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingApp.Services
{
    public class FlightBookingRepository : IFlightBookingRepository
    {
        private readonly FlightBookingContext _context;

        public FlightBookingRepository(FlightBookingContext context)
        {
            _context = context;
        }

        public async Task<FlightBooking> AddFlight(FlightBooking flightBooking)
        {
            var flightBookings = await _context.Flights.AddAsync(flightBooking);
            await _context.SaveChangesAsync();
            return flightBookings.Entity;
        }

        public async Task<FlightBooking> DeleteFlight(int id)
        {
            var result = await _context.Flights.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
            return result;
        }

        public async  Task<FlightBooking> EditFlight(FlightBooking booking, int id)
        {
            var flightEdited = await _context.Flights.FirstOrDefaultAsync(x => x.Id == id);
            if (flightEdited != null)
            {
                _context.Entry<FlightBooking>(flightEdited).CurrentValues.SetValues(booking);
                _context.SaveChanges();
            }
            return flightEdited;
        }

        public async Task<IEnumerable<FlightBooking>> GetAllFlight()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task<FlightBooking> GetFlightById(int id)
        {
            var result = await _context.Flights.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
