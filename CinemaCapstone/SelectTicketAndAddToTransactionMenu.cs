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
        foreach (var ticket in _tickets)
        {
            _menuItems.Add(new AddTicketToTransactionMenuItem(ticket, _transaction));
        }
        _menuItem()
        _menuItems.Add(new ExitMenuItem(this));
    }
}
/*
 * This class represents a menu item that allows the user to add a ticket to a transaction.
 * It inherits from the MenuItem class and implements the Select method to add the ticket to the transaction.
 */
/*
internal class AddTicketToTransactionMenuItem : MenuItem
{
    private Ticket _ticket;
    private Transaction _transaction;

    public AddTicketToTransactionMenuItem(Ticket ticket, Transaction transaction)
    {
        _ticket = ticket;
        _transaction = transaction;
    }

    public override void Select()
    {
        _transaction.AddTranscationItem(_ticket);
        Console.WriteLine($"Added ticket: {_ticket.Name}");
    }

    public override string MenuText()
    {
        return _ticket.Name;
    }
}
