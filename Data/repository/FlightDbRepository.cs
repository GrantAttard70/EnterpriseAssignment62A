using Data.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FlightDbRepository : IFlightDbRepository
    {

        private readonly AirlineDbContext _context;

        public FlightDbRepository(AirlineDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Flight>> GetAllFlights()
        {
            return _context.Flights.ToList();
        }

        public async Task<Flight> GetFlightById(int id)
        {
            return _context.Flights.Find(id);
        }

        public async Task AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        public async Task UpdateFlight(Flight flight)
        {
            _context.Flights.Update(flight);
            _context.SaveChanges();
        }

        public async Task DeleteFlight(int id)
        {
            var flight = _context.Flights.Find(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                _context.SaveChanges();
            }
        }

    }
}
