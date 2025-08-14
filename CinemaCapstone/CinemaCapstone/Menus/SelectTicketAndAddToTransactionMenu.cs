using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    internal class SelectTicketAndAddToTransactionMenu : ConsoleMenu
    {
        private IEnumerable<Ticket> _tickets;
        private Transaction _transaction;

        public SelectTicketAndAddToTransactionMenu(IEnumerable<Ticket> tickets, Transaction transaction)
        {
            _tickets = tickets;
            _transaction = transaction;
        }

        public override void CreateMenu()
        {
            Console.WriteLine(_transaction);
            _menuItems.Clear();
            foreach (Ticket t in _tickets)
            {
                _menuItems.Add(new AddTicketMenuItem(t, _transaction));
            }
            _menuItems.Add(new NavigateToConcessionMenuItem(_transaction));
            _menuItems.Add(new ExitMenuItem(this));

        }

        public override string MenuText()
        {
            return "Add ticket to transaction";
        }
    }
}
