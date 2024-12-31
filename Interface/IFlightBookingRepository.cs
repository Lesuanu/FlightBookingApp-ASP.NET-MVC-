using FlightBookingApp.Models;
using System.Collections.Generic;

namespace FlightBookingApp.Interface
{
    public interface IFlightBookingRepository
    {
        Task<FlightBooking> AddFlight(FlightBooking flightBooking);
        Task<IEnumerable<FlightBooking>> GetAllFlight();
        Task<FlightBooking> DeleteFlight(int Id);
        Task<FlightBooking> EditFlight(FlightBooking booking, int id);
        Task<FlightBooking> GetFlightById(int id);
    }
}
