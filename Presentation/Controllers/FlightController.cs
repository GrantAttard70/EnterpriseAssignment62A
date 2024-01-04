using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System.Diagnostics;
using System.Linq;

namespace Presentation.Controllers
{
    
    public class FlightController : Controller
    {
        private readonly IFlightDbRepository _IFR;
        public FlightController(IFlightDbRepository flightRepository)
        {
            _IFR = flightRepository;
        }

        public async Task<IActionResult> Index()
        {
            var flights = await _IFR.GetAllFlights();
            var flightViewModels = flights.Where(f => f.DepartureDate > DateTime.Now) 
                                           .Select(flight => new FlightViewModel
                                           {
                                               Id = flight.Id,
                                               DepartureDate = flight.DepartureDate,
                                               RetailPrice = CalculateRetailPrice(flight.WholesalePrice, flight.CommissionRate), 
                                                                                                                
                                           })
                                           .ToList();

            return View(flightViewModels);
        }
    }

    private decimal CalculateRetailPrice(decimal wholesalePrice, decimal commissionRate)
    {
        return wholesalePrice * (1 + commissionRate);
    }

    public async Task<IActionResult> Details(int id)
    {
        var flight = await _IFR.GetFlightByIdAsync(id);
        if (flight == null)
        {
            return NotFound();
        }

        var flightViewModel = new FlightViewModel
        {
            Id = flight.Id,
            DepartureDate = flight.DepartureDate,
            RetailPrice = CalculateRetailPrice(flight.WholesalePrice, flight.CommissionRate),

        };

        return View(flightViewModel);
    }



}
