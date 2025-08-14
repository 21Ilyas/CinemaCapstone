# Creating a Loyalty Scheme (10%)

// This class a Memberships to be created, which includes the customers name, email, visit count and whether they are a gold member

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

public void AddMembership(string name, string email)
{
    var membershipService = new MembershipService();
    

    _memberships[email] = new Membership(name, email);
    
    _memberships[email].VisitCount++;
}

//This class records the number of times a customer with a membership has visited and displays free next standard ticket at the 10th visit

internal class LoyaltyMembership : Membership
{


    public LoyaltyMembership(string memberName) : base(memberName) { }

    public void RecordVisit()
    {
        //base.RecordVisit();
        if (VisitCount == 10)
        {
            Console.WriteLine("Congratulations! Your next standard ticket is free.");
            VisitCount = 0; // Reset visit count after reward
        }
    }

    public void DisplayBenefits()
    {
        Console.WriteLine("Loyalty Membership Benefits: Free standard ticket after 10 visits.");
    }
}


In the workflow sections you must give clear instructions as to how to perform this workflow in your applcation. Use images and diagrams where necessary. Failure to give adequate instructions here may result in loss of marks.

This workflow should do the following things:
- Load information about members
- Any worker can add a member by providing a first name, surname and email address
- When a member visits 10 times their next standard ticket is free


