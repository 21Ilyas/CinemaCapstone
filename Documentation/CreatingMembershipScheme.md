# Expanding the Loyalty Scheme to Include Gold Membership (10%)

//This class show the menu which gives options to add customers to a membership and upgrade memberships to gold (with a 25% discount on concessions)

internal class MembershipMenu : ConsoleMenu
{
    private Transaction _transaction;
    private MembershipService _membershipService;

    new string name = string.Empty;
    new string email = string.Empty;

    public MembershipMenu(Transaction transaction, MembershipService membershipService)
    {
        _membershipService = membershipService; 
    }

    // Menu options
    public override void CreateMenu()
    {
        _menuItems.Clear();
        _menuItems.Add(new AddMembershipMenuItem(_membershipService));
        _menuItems.Add(new ExistingMembershipMenuItem(_membershipService, _transaction));
        _menuItems.Add(new UpgradeToGoldMembershipMenuItem(_membershipService));
        _menuItems.Add(new ExitMenuItem(this));
    }

    public override string MenuText()
    {
        return "Membership Options";
    }
}

internal class AddMembershipMenuItem : MenuItem
{
    private MembershipService _membershipService;

    public AddMembershipMenuItem(MembershipService membershipService)
    {
        _membershipService = membershipService;
    }

    /// Method to add a new membership
    public override void Select()
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter your email:");
        string email = Console.ReadLine();

        var membership = new Membership(name, email);
        var _membershipService = new MembershipService();
        _membershipService.AddMembership(membership.Name, membership.Email);

        Console.WriteLine("Loyalty membership added successfully!");
    }

    public override string MenuText()
    {
        return "Add Loyalty Membership";
    }
}

internal class ExistingMembershipMenuItem : MenuItem
{
    private MembershipService _membershipService;
    private Transaction _transaction;

    public ExistingMembershipMenuItem(MembershipService membershipService, Transaction transaction)
    {
        _membershipService = membershipService;
        _transaction = transaction;
    }

    // Method to check existing membership
    public override void Select()
    {
        Console.WriteLine("Enter your email to check membership:");
        string email = Console.ReadLine();

        var membership = _membershipService.GetMembership(email);
        if (membership != null)
        {
            Console.WriteLine($"Membership found: {membership}");
            if (membership.IsGoldMember)
            {
                Console.WriteLine("You are a Gold Member! Enjoy 25% discount on concessions.");
                _transaction.ApplyDiscount(0.25);
            }
        }
        else
        {
            Console.WriteLine("No membership found with the provided email.");
        }
    }

    public override string MenuText()
    {
        return "Check Existing Membership";
    }
}

internal class UpgradeToGoldMembershipMenuItem : MenuItem
{
    private MembershipService _membershipService;



    public UpgradeToGoldMembershipMenuItem(MembershipService membershipService)
    {
        _membershipService = membershipService;
    }

    // Method to upgrade to Gold Membership
    public override void Select()
    {
        Console.WriteLine("Enter your email to upgrade to Gold Membership:");
        string email = Console.ReadLine();
        var _membershipService = new MembershipService();
        Console.WriteLine("Successfully upgraded to Gold Membership!");
        
    }

    public override string MenuText()
    {
        return "Upgrade to Gold Membership";
    }
}

internal class MembershipService
{
    public Dictionary<string, Membership> _memberships = new Dictionary<string, Membership>();

    // Adds a new membership
    public void AddMembership(string name, string email)
    {
        var membershipService = new MembershipService();
        

        _memberships[email] = new Membership(name, email);
        
        _memberships[email].VisitCount++;
    }

    // Gets a membership by email
    public Membership GetMembership(string email)
    {
        _memberships.TryGetValue(email, out var membership);
        return membership;
    }

    // Upgrades to Gold Membership
    public bool UpgradeToGold(string email)
    {
        var membershipService = new MembershipService();

        if (_memberships.TryGetValue(email, out var membership))
        {
            membership.IsGoldMember = true;
            return true;
        }
        return false;
    }
}

//Method to apply a discount in the concessions class
public void ApplyDiscount(int discountPercentage)
{
    if (discountPercentage < 0 || discountPercentage > 100)
    {
        throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 100");
    }

    discountedPrice = _priceInPence - (_priceInPence * discountPercentage / 100);
}


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


In the workflow sections you must give clear instructions as to how to perform this workflow in your applcation. Use images and diagrams where necessary. Failure to give adequate instructions here may result in loss of marks.

This workflow should do the following things:
- Load information about members
- Sell an annual membership to turn a loyalty scheme member into a gold member
- Gold members get a 25% discount on all concessions

