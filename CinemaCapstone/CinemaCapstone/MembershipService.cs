using System;
using System.Collections.Generic;

namespace Capstone
{
    internal class MembershipService
    {
        public Dictionary<string, Membership> _memberships = new Dictionary<string, Membership>();

        // Adds a new membership
        public void AddMembership(string name, string email)
        {
            var membershipService = new MembershipService();
            

            _memberships[email] = new Membership(name, email);
            
            _memberships[email].VisitCount++;
        }

        // Gets a membership by email
        public Membership GetMembership(string email)
        {
            _memberships.TryGetValue(email, out var membership);
            return membership;
        }

        // Upgrades to Gold Membership
        public bool UpgradeToGold(string email)
        {
            var membershipService = new MembershipService();

            if (_memberships.TryGetValue(email, out var membership))
            {
                membership.IsGoldMember = true;
                return true;
            }
            return false;
        }
    }

}
