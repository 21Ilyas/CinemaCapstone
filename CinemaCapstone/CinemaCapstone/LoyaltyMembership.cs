using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    internal class LoyaltyMembership : Membership
    {


        public LoyaltyMembership(string memberName) : base(memberName) { }

        public void RecordVisit()
        {
            //base.RecordVisit();
            if (VisitCount == 10)
            {
                Console.WriteLine("Congratulations! Your next standard ticket is free.");
                VisitCount = 0; // Reset visit count after reward
            }
        }

        public void DisplayBenefits()
        {
            Console.WriteLine("Loyalty Membership Benefits: Free standard ticket after 10 visits.");
        }
    }
}
