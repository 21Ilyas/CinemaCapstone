using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class MembershipMenu : ConsoleMenu
    {
        private Transaction _transaction;
        private MembershipService _membershipService;

        new string name = string.Empty;
        new string email = string.Empty;

        public MembershipMenu(Transaction transaction, MembershipService membershipService)
        {
            _membershipService = membershipService; 
        }

        // Menu options
        public override void CreateMenu()
        {
            _menuItems.Clear();
            _menuItems.Add(new AddMembershipMenuItem(_membershipService));
            _menuItems.Add(new ExistingMembershipMenuItem(_membershipService, _transaction));
            _menuItems.Add(new UpgradeToGoldMembershipMenuItem(_membershipService));
            _menuItems.Add(new ExitMenuItem(this));
        }

        public override string MenuText()
        {
            return "Membership Options";
        }
    }

    internal class AddMembershipMenuItem : MenuItem
    {
        private MembershipService _membershipService;

        public AddMembershipMenuItem(MembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        /// Method to add a new membership
        public override void Select()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();

            var membership = new Membership(name, email);
            var _membershipService = new MembershipService();
            _membershipService.AddMembership(membership.Name, membership.Email);

            Console.WriteLine("Loyalty membership added successfully!");
        }

        public override string MenuText()
        {
            return "Add Loyalty Membership";
        }
    }

    internal class ExistingMembershipMenuItem : MenuItem
    {
        private MembershipService _membershipService;
        private Transaction _transaction;

        public ExistingMembershipMenuItem(MembershipService membershipService, Transaction transaction)
        {
            _membershipService = membershipService;
            _transaction = transaction;
        }

        // Method to check existing membership
        public override void Select()
        {
            Console.WriteLine("Enter your email to check membership:");
            string email = Console.ReadLine();

            var membership = _membershipService.GetMembership(email);
            if (membership != null)
            {
                Console.WriteLine($"Membership found: {membership}");
                if (membership.IsGoldMember)
                {
                    Console.WriteLine("You are a Gold Member! Enjoy 25% discount on concessions.");
                    _transaction.ApplyDiscount(0.25);
                }
            }
            else
            {
                Console.WriteLine("No membership found with the provided email.");
            }
        }

        public override string MenuText()
        {
            return "Check Existing Membership";
        }
    }

    internal class UpgradeToGoldMembershipMenuItem : MenuItem
    {
        private MembershipService _membershipService;



        public UpgradeToGoldMembershipMenuItem(MembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        // Method to upgrade to Gold Membership
        public override void Select()
        {
            Console.WriteLine("Enter your email to upgrade to Gold Membership:");
            string email = Console.ReadLine();
            var _membershipService = new MembershipService();
            Console.WriteLine("Successfully upgraded to Gold Membership!");
            
        }

        public override string MenuText()
        {
            return "Upgrade to Gold Membership";
        }
    }
}
