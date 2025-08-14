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


