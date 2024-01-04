using Data.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class TicketDbRepository : ITicketDBRepository
    {
        private readonly AirlineDbContext _context;
        private readonly IFlightDbRepository _flightRepository;

        public TicketDbRepository(AirlineDbContext context, IFlightDbRepository flightRepository)
        {
            _context = context;
            _flightRepository = flightRepository;
        }

        public Ticket BookTicket(Ticket ticket)
        {
            var existingTicket = _context.Tickets
                .FirstOrDefault(t => t.FlightIdFK == ticket.FlightIdFK && t.Row == ticket.Row && t.Column == ticket.Column);

            if (existingTicket != null)
            {
                throw new InvalidOperationException("This seat is already booked.");
            }

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public void CancelTicket(int ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);
            if (ticket == null)
            {
                throw new InvalidOperationException("Ticket not found.");
            }

            ticket.Cancelled = true;
            _context.SaveChanges();
        }

        public IEnumerable<Ticket> GetTicketsByFlight(int flightId)
        {
            return _context.Tickets
                .Where(t => t.FlightIdFK == flightId)
                .ToList();
        }
        Task<Ticket> ITicketDBRepository.BookTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        Task ITicketDBRepository.CancelTicket(int ticketId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Ticket>> ITicketDBRepository.GetTicketsByFlight(int flightId)
        {
            throw new NotImplementedException();
        }
    }
}
