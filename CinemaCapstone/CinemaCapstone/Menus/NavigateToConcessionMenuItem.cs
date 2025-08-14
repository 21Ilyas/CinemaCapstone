using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    internal class NavigateToConcessionMenuItem : MenuItem
    {
        private Transaction _transaction;

        public NavigateToConcessionMenuItem(Transaction transaction)
        {
            _transaction = transaction;
        }

        // Selects the concession menu
        public override void Select()
        {
            var concessionMenu = new SelectConcessionAndAddToTransactionMenu(GetAvailableConcessions(), _transaction);
            concessionMenu.CreateMenu();
            concessionMenu.Select();
        }

        public override string MenuText()
        {
            return "Switch to Concession menu";
        }

        private IEnumerable<Concession> GetAvailableConcessions()
        {
            // Gets available Concessions
            return new List<Concession>
            {
                new Concession("Popcorn", 500),
                new Concession("Soda", 300),
                new Concession("Candy", 200),
                new Concession("Nachos", 700)
            };
        }
    }
}
