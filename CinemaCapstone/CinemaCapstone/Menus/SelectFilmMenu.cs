using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    internal class SelectFilmMenu : ConsoleMenu
    {
        private IEnumerable<Film> _films;
        private Transaction _transaction;

        public SelectFilmMenu(IEnumerable<Film> films, Transaction transaction)
        {
            _films = films;
            _transaction = transaction;
        }

        // Creates the menu items for selecting films and adding them to the transaction
        public override void CreateMenu()
        {
            Console.WriteLine(_transaction);
            _menuItems.Clear();
            foreach (Film f in _films)
            {
                _menuItems.Add(new AddFilmMenuItem(f, _transaction));
            }
            _menuItems.Add(new NavigateToTicketMenuItem(_transaction)); 
            _menuItems.Add(new ExitMenuItem(this)); // Allows exiting the menu

        }

        public override string MenuText()
        {
            return "Select a film";
        }
    }
}
