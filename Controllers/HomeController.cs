using FlightBookingApp.Interface;
using FlightBookingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlightBookingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlightBookingRepository _flightBookingRepository;

        public HomeController(ILogger<HomeController> logger, IFlightBookingRepository flightBookingRepository)
        {
            _logger = logger;
            _flightBookingRepository = flightBookingRepository;
        }

        //[HttpGet]
        //public async Task<IActionResult> ListFlights()
        //{
        //    await _flightBookingRepository.GetAllFlight();
        //    return Ok("success");
        //}

        public IActionResult Index()
        {
            return View();
        }

     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
