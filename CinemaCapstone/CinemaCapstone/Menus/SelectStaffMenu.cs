using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    internal class SelectStaffMenu : ConsoleMenu
    {
        private IEnumerable<Staff> _staffMembers;
        private IEnumerable<Screening> screenings;
        private Transaction _transaction;
        private MembershipService membershipService;

        public Staff? SelectedStaff { get; private set; }

        public SelectStaffMenu(IEnumerable<Staff> staffMembers, IEnumerable<Screening> screenings, Transaction transaction)
        {
            _staffMembers = staffMembers ?? throw new ArgumentNullException(nameof(staffMembers), "Staff members cannot be null");
            this.screenings = screenings;
            _transaction = transaction;
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();

            foreach (var staff in _staffMembers)
            {
                _menuItems.Add(new SelectStaffMenuItem(staff, this));
            }

            // An option to exit
            _menuItems.Add(new ExitMenuItem(this));
        }

        public override string MenuText()
        {
            return "Select a staff member to log in";
        }

        private class SelectStaffMenuItem : MenuItem
        {
            private Staff _staff;
            private SelectStaffMenu _menu;

            public SelectStaffMenuItem(Staff staff, SelectStaffMenu menu)
            {
                _staff = staff;
                _menu = menu;
            }

            public override void Select()
            {
                _menu.SelectedStaff = _staff;

                var selectScreeningMenu = new SelectScreeningMenu(_menu.screenings,_menu._transaction, _menu.membershipService);
                selectScreeningMenu.CreateMenu();
                selectScreeningMenu.Select();
            }

            public override string MenuText()
            {
                return _staff.ToString();
            }
        }
    }
}
