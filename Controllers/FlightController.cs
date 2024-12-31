using FlightBookingApp.Interface;
using FlightBookingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingApp.Controllers
{
   
    public class FlightController : Controller
    {
        private readonly IFlightBookingRepository _flightBookingRepository;

        public FlightController(IFlightBookingRepository flightBookingRepository)
        {
            _flightBookingRepository = flightBookingRepository;
        }

        [HttpGet]
        public IActionResult Bookflight()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookFlight(FlightBooking booking)
        {
            await _flightBookingRepository.AddFlight(booking);
            return RedirectToAction(nameof(ListFlights));   
        }

        [HttpGet]
        public async Task<IActionResult> ListFlights()
        {
            var flights = await _flightBookingRepository.GetAllFlight();
            return View(flights);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFlight(int id)
        {
            var flight = await _flightBookingRepository.GetFlightById(id);
            return View(flight);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flights = await _flightBookingRepository.DeleteFlight(id);
           
            return View(flights);
        }

        [HttpGet]
        public async Task<IActionResult> EditFlight(int id)
        {
            var flight = await _flightBookingRepository.GetFlightById(id);
            return View(flight);
        }

        [HttpPost]
        public async Task<IActionResult> EditFlight(FlightBooking flightBooking, int id)
        {           
            var result = await _flightBookingRepository.EditFlight(flightBooking, id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> FlightDetails(int id)
        {
            var flight = await _flightBookingRepository.GetFlightById(id);
            return View(flight);
        }
    }
}

