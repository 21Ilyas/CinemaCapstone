using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    internal class Screening
    {
        private Film _film;
        private DateTime _startTime;
        private int _screenNumber;
        private int _seatsAvailable;

        public Screening(Film film, DateTime startTime, int screenNumber, int seatsAvailable)
        {
            _film = film ?? throw new ArgumentNullException(nameof(film), "Film cannot be null");
            _startTime = startTime;
            _screenNumber = screenNumber;
            _seatsAvailable = seatsAvailable >= 0 ? seatsAvailable : throw new ArgumentOutOfRangeException(nameof(seatsAvailable), "Seats available cannot be negative");
        }


        public Film Film
        {
            get { return _film; }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
        }

        public int ScreenNumber
        {
            get { return _screenNumber; }
        }

        public int SeatsAvailable
        {
            get { return _seatsAvailable; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Seats available cannot be negative");
                }
                _seatsAvailable = value;
            }
        }

        public bool ReserveSeat(int numberOfSeats)
        {
            if (numberOfSeats <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfSeats), "Number of seats to reserve must be greater than zero");
            }

            if (numberOfSeats > _seatsAvailable)
            {
                return false; // Not enough seats available
            }

            SeatsAvailable--; // Decrement the available seats by the number of seats reserved
            return true; // Reservation successful
        }

        public override string ToString()
        {
            return $"{_film.Title} - {StartTime:dd/MM/yyyy HH:mm} - Screen {_screenNumber} - Seats Available: {_seatsAvailable}";
        }

        
    }
}
