# Setting Schedules Workflow (10%)

In the workflow sections you must give clear instructions as to how to perform this workflow in your applcation. Use images and diagrams where necessary. Failure to give adequate instructions here may result in loss of marks.


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

//Shows staff level (manager or worker), name and ID
Staff[] staffMembers = new Staff[]
{
    new Manager("Ilyas Ghanimi", 101),
    new Worker("Bob Paul", 102),
    new Worker("Charlie Smith", 103),
    new Manager("Diana Wilson", 104)
};

// Method allowing managers to edit scheduel of screenings
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

// Shows film, length, age rating, date, time, screen, seats available
Screening[] screenings = new Screening[]
{
    new Screening(new Film("Gladiator", 120, "18"), new DateTime(2025, 8, 23, 18, 0, 0), 2, 50),
    new Screening(new Film("Iron Man", 150, "12"), new DateTime(2025, 8, 23, 20, 0, 0), 3, 30),
    new Screening(new Film("Mufasa", 150, "U"), new DateTime(2025, 8, 23, 14, 0, 0), 4, 40),
    new Screening(new Film("Maze Runner", 130, "15"), new DateTime(2025, 8, 24, 16, 0, 0), 5, 20),
    new Screening(new Film("Holiday", 120, "12"), new DateTime(2025, 8, 24, 18, 0, 0), 6, 25)
};



This workflow should do the following things:

- Load information about cinema staff who can either be managers or workers without allowing invalid data
- Select a staff member at the start of the application
- A manager should be able to edit the schedule of screenings
- The schedule must conform to the scheduling rules
    - You cannot schedule two screenings in the same screen at the same time
    - You must leave enough time between films for "turnaround" (15 minutes for 50 seats or less, 30 minutes for 51 - 100 seats, 45 minutes for more than 100 seats)
- A manager should be able to save the schedule of screenings in a format of your choosing with the extension .fs
    - one file should contain the schedule for one day, with the date indicated in the filename 
- Any staff member should be able to load the schedule from a list of dates

