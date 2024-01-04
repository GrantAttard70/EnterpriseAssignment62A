using Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IFlightDbRepository _flightRepository;
        private readonly ITicketDBRepository _ticketRepository;
        
        public TicketsController(IFlightDbRepository flightRepository, ITicketDBRepository ticketRepository)
        {
            _flightRepository = flightRepository;
            _ticketRepository = ticketRepository;
        }

        public IActionResult ShowAvailableFlights()
        {

            var allFlights = _flightRepository.GetAllFlights();
            //var availableFlights = allFlights
            //.Where(flight => !IsFullyBooked(flight) && flight.DepartureDate > DateTime.Now)
            //.ToList(); 

            //return View(availableFlights); 
            throw new NotImplementedException();
        }

    }
}
