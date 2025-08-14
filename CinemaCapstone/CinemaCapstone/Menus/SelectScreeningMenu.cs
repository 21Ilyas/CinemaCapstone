using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    internal class SelectScreeningMenu : ConsoleMenu
    {
        private IEnumerable<Screening> _screenings;
        private Transaction _transaction;
        //private MembershipService _membershipService;

        public MembershipService _membershipService { get; set; }

        public Ticket? Ticket { get; set; } // Nullable to allow for no ticket selection

        public SelectScreeningMenu(IEnumerable<Screening> screenings, Transaction transaction, MembershipService membershipService)
        {
            _screenings = screenings ?? throw new ArgumentNullException(nameof(screenings), "Screenings cannot be null");
            _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction), "Transaction cannot be null");
            _membershipService = membershipService;
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();

            foreach (var screening in _screenings)
            {
                _menuItems.Add(new AddScreeningMenuItem(screening, _transaction));
            }
            _menuItems.Add(new NavigateToMembershipMenuItem(_transaction, _membershipService));
            _menuItems.Add(new NavigateToTicketMenuItem(_transaction)); // Allows adding a ticket to the transaction
            //option to exit
            _menuItems.Add(new ExitMenuItem(this));
        }
        

        public override string MenuText()
        {
            return "Select a screening for the film";
        }
    }
}
