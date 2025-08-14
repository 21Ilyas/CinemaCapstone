using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    internal class Manager : Staff
    {
        public Manager(string name, int id) : base(name, "Manager", id)
        {
        }
        
        public void EditScreenings(List<Screening> screenings)
        {
            if (screenings == null || screenings.Count == 0)
            {
                throw new ArgumentException("Screenings list cannot be null or empty", nameof(screenings));
            }

            // Edit screenings
            Console.WriteLine("Editing screenings...");
            foreach (var screening in screenings)
            {
                Console.WriteLine($"Editing screening: {screening}");
            }
        }

    }
}
