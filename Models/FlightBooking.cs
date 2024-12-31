namespace FlightBookingApp.Models
{
    public class FlightBooking
    {
        public int Id { get; set; }
        public FlightName Flight_Name { get; set; }
        public FlightClass Flight_Class { get; set; }
        public string Destination { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public DateTime Arrival_Time { get; set; }
        public DateTime Departure_Time { get; set; }
    }
}
