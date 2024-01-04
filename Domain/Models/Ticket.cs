using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ticket
    {

        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int FlightIdFK { get; set; }
        public string Passport { get; set; }
        public decimal PricePaid { get; set; }
        public bool Cancelled { get; set; }

    }
}
