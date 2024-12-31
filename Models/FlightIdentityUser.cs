using Microsoft.AspNetCore.Identity;

namespace FlightBookingApp.Models
{
    public class FlightIdentityUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

    }
}
