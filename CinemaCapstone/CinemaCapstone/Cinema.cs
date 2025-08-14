using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    internal class Cinema
    {
        // Represents information about the cinema, including the films, concessions, and tickets available.
        public IEnumerable<Film> Films;
        public IEnumerable<Concession> Concessions;
        public IEnumerable<Ticket> Tickets;
        private List<Transaction> _transactions;

        public Cinema(IEnumerable<Film> films, IEnumerable<Concession> concessions, IEnumerable<Ticket> tickets)
        {
            Films = films;
            Concessions = concessions;
            Tickets = tickets;
            _transactions = new List<Transaction>();
        }
    }
}
