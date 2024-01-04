using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ITicketDBRepository
    {
        Task<Ticket> BookTicket(Ticket ticket);
        Task CancelTicket(int ticketId);
        Task<IEnumerable<Ticket>> GetTicketsByFlight(int flightId);
    }
}
