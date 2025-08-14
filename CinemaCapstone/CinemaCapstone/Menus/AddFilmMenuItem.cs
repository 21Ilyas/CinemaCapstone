using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    internal class AddFilmMenuItem : MenuItem
    {
        private Film _film;
        private Transaction _transaction;

        public AddFilmMenuItem(Film film, Transaction transaction)
        {
            _film = film;
            _transaction = transaction;
        }

        public override string MenuText()
        {
            return _film.ToString();
        }

        public override void Select()
        {
            _transaction.AddFilm(_film);
            //SelectTicketAndAddToTransactionMenu Menu = new SelectTicketAndAddToTransactionMenu(tickets, _transaction);
            //SelectTicketAndAddToTransactionMenu.CreateMenu();
            //SelectTicketAndAddToTransactionMenu.Select();

            // Assuming you have a method to handle the selection of a film
            // This could be adding the film to a transaction or displaying its details
            //Console.WriteLine($"You selected: {_film.Title}");
            // Here you might want to navigate to another menu or perform an action with the selected film
            // For example, you could navigate to a screening selection menu for this film
            // var screeningMenu = new SelectScreeningMenu(_film);
            // screeningMenu.CreateMenu();
            // screeningMenu.Select();
        }
    }
}
