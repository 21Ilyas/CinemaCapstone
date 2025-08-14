# Self commenting code and explicit comments (5%)


// As an example, in the membership class i have used properties such as IsGoldMember and VisitCount which which ensures encapsulation and flexability

internal class Membership
{
    private string memberName;

    public string Name { get; }
    public string Email { get; }
    public bool IsGoldMember { get; set; }
    public int VisitCount { get; set; }

    // constructor for creating a new membership
    public Membership(string name, string email)
    {
        Name = name;
        Email = email;
        IsGoldMember = false;
        VisitCount = 0;
    }

    public Membership(string memberName)
    {
        this.memberName = memberName;
    }

    // Display the member's name and email
    public override string ToString()
    {
        return $"{Name} ({Email}) - {(IsGoldMember ? "Gold Member" : "Loyalty Member")}, Visits: {VisitCount}";
    }

}

// In the transaction class i have used clear and helpful commenting which explains the use of each method

internal class Transaction
{
    private Film? _film; 
    private Screening? _screening; 
    private List<Concession> _concessions;
    private List<Ticket> _tickets;

    
    public Transaction()
    {
        _concessions = new List<Concession>();
        _tickets = new List<Ticket>();
    }

    // Method to add a film to the transaction
    public void AddFilm(Film film)
    {
        if (film == null)
        {
            throw new ArgumentNullException(nameof(film), "Film cannot be null");
        }

        if (_film != null)
        {
            throw new InvalidOperationException("A film has already been selected for this transaction.");
        }

        _film = film;
    }

    // Method to add a screening to the transaction
    public void AddScreening(Screening screening)
    {
        if (screening == null)
        {
            throw new ArgumentNullException(nameof(screening), "Screening cannot be null");
        }

        if (_screening != null)
        {
            throw new InvalidOperationException("A screening has already been selected for this transaction.");
        }

        _screening = screening;
    }

    // Method to add a concession to the transaction
    public void AddConcession(Concession concession)
    {
        if (concession == null)
        {
            throw new ArgumentNullException(nameof(concession), "Concession cannot be null");
        }
        _concessions.Add(concession);
    }

    // Method to add a ticket to the transaction
    public void AddTicket(Ticket ticket)
    {
        if (ticket == null)
        {
            throw new ArgumentNullException(nameof(ticket), "Ticket cannot be null");
        }
        _tickets.Add(ticket);
    }

    // Method to apply a discount for Gold members
    public void ApplyDiscount(double v)
    {
        const double discountRate = 0.25;
        foreach (var concession in _concessions)
        {
            int originalPrice = concession.PriceInPence;
            int discountedPrice = (int)(originalPrice * (1 - discountRate));
            concession.ApplyDiscount((int)(discountRate * 100));
        }
    }

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
    
}    


Describe how you have documented your code in terms of naming conventions for member variables and member methods, explicit comments (that add value and not clutter) and summary comments.

