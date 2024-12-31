using System.ComponentModel.DataAnnotations;

namespace FlightBookingApp.Models
{
    public class SignInModel
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }

    }
}
