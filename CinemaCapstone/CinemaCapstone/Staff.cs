using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    internal abstract class Staff
    {
        public string Name { get; }
        public string Role { get; }
        public int ID { get; } 

        protected Staff(string name, string role, int id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null");
            Role = role ?? throw new ArgumentNullException(nameof(role), "Role cannot be null");

            string allowedChars = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (char c in name)
            {
                if (!allowedChars.Contains(c))
                {
                    throw new ArgumentException("Name can only contain letters and spaces", nameof(name));
                }
            }

            ID = id;

            if (ID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be a positive integer");
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Role}) - ID:{ID}";
        }

    }
}
