using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    internal class Film
    {
        private string _title;
        private int _length;
        private string _ageRating;

        public string Title
        {
            get { return _title; }
        }

        public int Length
        {
            get { return _length; }
        }

        public string AgeRating
        {
            get { return _ageRating; }
        }

        public Film(string title, int length, string ageRating)
        {
            string allowedChars = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            foreach (char c in title)
            {
                if (!allowedChars.Contains(c))
                {
                    throw new ArgumentException("Title can only contain letters, numbers and spaces");
                }
            }
            
            _title = title;

            string allowedRatings = "U"+"12"+"15"+"18";

            if (!allowedRatings.Contains(ageRating))
            {
                throw new ArgumentException("Age rating must be one of the following: U, 12, 15, 18");
            }
            
            _ageRating = ageRating;

            if (length <= 0)
            {
                throw new ArgumentException("Length must be a positive integer");
            }
            
            _length = length;
        }

        public override string ToString()
        {
            return $"{_title} - {_length} minutes - Age Rating: {_ageRating}";
        }
    }
}
