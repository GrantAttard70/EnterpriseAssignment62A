using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IFlightDbRepository
    {
        Task<IEnumerable<Flight>> GetAllFlights();
        Task<Flight> GetFlightById(int id);

        Task AddFlight(Flight flight);
        Task UpdateFlight(Flight flight);
        Task DeleteFlight(int id);
    }
}


