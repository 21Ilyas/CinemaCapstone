using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    internal class NavigateToMembershipMenuItem : MenuItem
    {
        private Transaction _transaction;
        private MembershipService _membershipService;

        public NavigateToMembershipMenuItem(Transaction transaction, MembershipService membershipService)
        {
            _transaction = transaction;
            _membershipService = membershipService;
        }

        // Selects the membership menu
        public override void Select()
        {
            var membershipMenu = new MembershipMenu(_transaction, _membershipService);
            membershipMenu.CreateMenu();
            membershipMenu.IsActive = true;

            while (membershipMenu.IsActive)
            {
                Console.Clear();
                membershipMenu.Select();
            }
        }

        public override string MenuText()
        {
            return "Go to Membership Menu";
        }
    }
}
