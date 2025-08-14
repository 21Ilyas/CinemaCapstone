using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Capstone.Menus
{
    internal class SelectConcessionAndAddToTransactionMenu : ConsoleMenu
    {
        private IEnumerable<Concession> _concessions;
        private Transaction _transaction;
       

        public SelectConcessionAndAddToTransactionMenu(IEnumerable<Concession> concessions, Transaction transaction)
        {
            _concessions = concessions;
            _transaction = transaction;
        }

        // Creates the menu items for selecting concessions and adding them to the transaction
        public override void CreateMenu()
        {
            Console.WriteLine(_transaction);
            _menuItems.Clear();
            foreach (Concession c in _concessions)
            {
                _menuItems.Add(new AddConcessionMenuItem(c, _transaction));
            }
            _menuItems.Add(new NavigateToTicketMenuItem(_transaction));
            _menuItems.Add(new ExitMenuItem(this));
        }

        public override string MenuText()
        {
            return "Add concession to transaction";
        }
        
    }
}
