using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    internal class AddTicketMenuItem : MenuItem
    {
        private Ticket _ticket;
        private Transaction _transaction;

        public AddTicketMenuItem(Ticket ticket, Transaction transaction)
        {
            _ticket = ticket;
            _transaction = transaction;
        }

        public override string MenuText()
        {
            return _ticket.ToString();
        }

        /// Selects tickets and adds to the transaction.
        public override void Select()
        {
            _transaction.AddTicket(_ticket);
            

        }
    }
}
