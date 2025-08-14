using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    internal class Concession
    {
        private string _name;
        private int _priceInPence;
        public int discountedPrice = 0;
        public string Name
        {
            get { return _name; }
        }

        public int PriceInPence
        {
            get { return _priceInPence; }
        }

        // Constructor for creating Concessions
        public Concession(string name, int priceInPence)
        {
            string allowedChars = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            foreach (char c in name)
            {
                if (!allowedChars.Contains(c))
                {
                    throw new ArgumentException("Name can only contain letters, numbers and spaces");
                }
            }

            if (priceInPence <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(priceInPence), "Price cannot be negative or zero");
            }

            _name = name;
            _priceInPence = priceInPence;
        }

        public override string ToString()
        {
            return $"{_name} - £{_priceInPence / 100.0:F2}";
        }


        public void ApplyDiscount(int discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 100");
            }

            discountedPrice = _priceInPence - (_priceInPence * discountPercentage / 100);
        }

    }
}
