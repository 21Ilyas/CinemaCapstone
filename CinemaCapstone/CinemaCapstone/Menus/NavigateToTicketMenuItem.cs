using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    internal class NavigateToTicketMenuItem : MenuItem
    {
        private Transaction _transaction;

        public NavigateToTicketMenuItem(Transaction transaction)
        {
            _transaction = transaction;
        }

        // Selects the ticket menu
        public override void Select()
        {
            var ticketMenu = new SelectTicketAndAddToTransactionMenu(GetAvailableTickets(), _transaction);
            ticketMenu.CreateMenu();
            ticketMenu.Select();


        }

        public override string MenuText()
        {
            return "Switch to ticket menu";
        }

        

        private IEnumerable<Ticket> GetAvailableTickets()
        {
            // Gets available tickets
            return new List<Ticket>
            {
                new Ticket("Adult", 1200),
                new Ticket("Child", 800),
                new Ticket("Premium Adult", 1800),
                new Ticket("Premium Child", 1200)
            };
        }
    }
}
