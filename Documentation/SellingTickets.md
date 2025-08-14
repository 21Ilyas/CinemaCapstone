# Selling Tickets Workflow (10%)

In the workflow sections you must give clear instructions as to how to perform this workflow in your applcation. Use images and diagrams where necessary. Failure to give adequate instructions here may result in loss of marks.

// This ticket menu allows the user to select the ticket type (adult, child, premium adult, premium child) and adds it to the current transaction.
//This menu also allows the user to switch to the concessions menu were concessions can be added in the same transaction.


internal class SelectTicketAndAddToTransactionMenu : ConsoleMenu
{
    private IEnumerable<Ticket> _tickets;
    private Transaction _transaction;

    public SelectTicketAndAddToTransactionMenu(IEnumerable<Ticket> tickets, Transaction transaction)
    {
        _tickets = tickets;
        _transaction = transaction;
    }

    public override void CreateMenu()
    {
        Console.WriteLine(_transaction);
        _menuItems.Clear();
        foreach (Ticket t in _tickets)
        {
            _menuItems.Add(new AddTicketMenuItem(t, _transaction));
        }
        _menuItems.Add(new NavigateToConcessionMenuItem(_transaction));
        _menuItems.Add(new ExitMenuItem(this));

    }

    public override string MenuText()
    {
        return "Add ticket to transaction";
    }
}


// This Concession menu allows the user to select concessions such as popcorn and soda and adds it to the current transaction.
//This menu also allows the user to switch back to the tickets menu were tickets can be added in the same transaction.


internal class SelectConcessionAndAddToTransactionMenu : ConsoleMenu
{
    private IEnumerable<Concession> _concessions;
    private Transaction _transaction;
   

    public SelectConcessionAndAddToTransactionMenu(IEnumerable<Concession> concessions, Transaction transaction)
    {
        _concessions = concessions;
        _transaction = transaction;
    }

    // Creates the menu items for selecting concessions and adding them to the transaction
    public override void CreateMenu()
    {
        Console.WriteLine(_transaction);
        _menuItems.Clear();
        foreach (Concession c in _concessions)
        {
            _menuItems.Add(new AddConcessionMenuItem(c, _transaction));
        }
        _menuItems.Add(new NavigateToTicketMenuItem(_transaction));
        _menuItems.Add(new ExitMenuItem(this));
    }

    public override string MenuText()
    {
        return "Add concession to transaction";
    }
    
}
Concession[] concessions = new Concession[]
{
    new Concession("Popcorn", 500),
    new Concession("Soda", 300),
    new Concession("Candy", 200),
    new Concession("Nachos", 700)
};

// This screening menu allows the user to select screenings to films with specific times, screens and age rating.
//Also the selected screening is added in the same transaction.

internal class SelectScreeningMenu : ConsoleMenu
{
    private IEnumerable<Screening> _screenings;
    private Transaction _transaction;
    //private MembershipService _membershipService;

    public MembershipService _membershipService { get; set; }

    public Ticket? Ticket { get; set; } // Nullable to allow for no ticket selection

    public SelectScreeningMenu(IEnumerable<Screening> screenings, Transaction transaction, MembershipService membershipService)
    {
        _screenings = screenings ?? throw new ArgumentNullException(nameof(screenings), "Screenings cannot be null");
        _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction), "Transaction cannot be null");
        _membershipService = membershipService;
    }

    public override void CreateMenu()
    {
        _menuItems.Clear();

        foreach (var screening in _screenings)
        {
            _menuItems.Add(new AddScreeningMenuItem(screening, _transaction));
        }
        _menuItems.Add(new NavigateToMembershipMenuItem(_transaction, _membershipService));
        _menuItems.Add(new NavigateToTicketMenuItem(_transaction)); // Allows adding a ticket to the transaction
        //option to exit
        _menuItems.Add(new ExitMenuItem(this));
    }
    

    public override string MenuText()
    {
        return "Select a screening for the film";
    }
}
//Shows the film, length, age rating, date, time, screen, seats available
Screening[] screenings = new Screening[]
{
    new Screening(new Film("Gladiator", 120, "18"), new DateTime(2025, 8, 23, 18, 0, 0), 2, 50),
    new Screening(new Film("Iron Man", 150, "12"), new DateTime(2025, 8, 23, 20, 0, 0), 3, 30),
    new Screening(new Film("Mufasa", 150, "U"), new DateTime(2025, 8, 23, 14, 0, 0), 4, 40),
    new Screening(new Film("Maze Runner", 130, "15"), new DateTime(2025, 8, 24, 16, 0, 0), 5, 20),
    new Screening(new Film("Holiday", 120, "12"), new DateTime(2025, 8, 24, 18, 0, 0), 6, 25)
};



// Calculatest the total price of the current transaction
// Display transaction details
public override string ToString()
{
    StringBuilder sb = new StringBuilder();
    int transactionTotalInPence = 0;

    sb.AppendLine("Film:");
    if (_film != null)
    {
        sb.AppendLine(_film.ToString());
    }
    else
    {
        sb.AppendLine("No film selected.");
    }

    sb.AppendLine("Screening:");
    if (_screening != null)
    {
        sb.AppendLine(_screening.ToString());
    }
    else
    {
        sb.AppendLine("No screening selected.");
    }

    sb.AppendLine("Concessions:");
    foreach (Concession concession in _concessions)
    {
        sb.AppendLine(concession.ToString());
        transactionTotalInPence += concession.PriceInPence;
    }

    sb.AppendLine("Tickets:");
    foreach (Ticket ticket in _tickets)
    {
        sb.AppendLine(ticket.ToString());
        transactionTotalInPence += ticket.PriceInPence;
    }

    sb.AppendLine($"Total: £{transactionTotalInPence / 100.0:F2}");
    return sb.ToString();
}

// This cinema class stores information about the cinema
internal class Cinema
{
    // Represents information about the cinema, including the films, concessions, and tickets available.
    public IEnumerable<Film> Films;
    public IEnumerable<Concession> Concessions;
    public IEnumerable<Ticket> Tickets;
    private List<Transaction> _transactions;

    public Cinema(IEnumerable<Film> films, IEnumerable<Concession> concessions, IEnumerable<Ticket> tickets)
    {
        Films = films;
        Concessions = concessions;
        Tickets = tickets;
        _transactions = new List<Transaction>();
    }
}

This workflow should do the following things:

- Load information about the cinema without allowing invalid data
- Load information about the schedule of screenings without allowing invalid data
- Select a film screening
- Select a number of tickets to buy
- Select standard or premium tickets
- Select concessions
- Select popcorn and/or soda
- Calculate the total price of the transaction
- Demonstrate the number of tickets available has updated
- Save updated information about screenings




