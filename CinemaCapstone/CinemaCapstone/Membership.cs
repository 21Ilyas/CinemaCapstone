using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    internal class Membership
    {
        private string memberName;

        public string Name { get; }
        public string Email { get; }
        public bool IsGoldMember { get; set; }
        public int VisitCount { get; set; }

        // constructor for creating a new membership
        public Membership(string name, string email)
        {
            Name = name;
            Email = email;
            IsGoldMember = false;
            VisitCount = 0;
        }

        public Membership(string memberName)
        {
            this.memberName = memberName;
        }

        // Display the member's name and email
        public override string ToString()
        {
            return $"{Name} ({Email}) - {(IsGoldMember ? "Gold Member" : "Loyalty Member")}, Visits: {VisitCount}";
        }

    }
}
