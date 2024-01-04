namespace Presentation.Models
{
    public class TicketViewModel
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public decimal Price { get; set; } 


        public string PassengerName { get; set; }  
        public string PassengerEmail { get; set; } 


        public string SeatNumber { get; set; } 
                                    

        public string ErrorMessage { get; set; }
        public string ConfirmationMessage { get; set; }
    }
}