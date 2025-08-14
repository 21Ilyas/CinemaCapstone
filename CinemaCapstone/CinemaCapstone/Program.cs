using Capstone;
using Capstone.Menus;
using System.Transactions;

Console.WriteLine("Hello, Capstone!");

Staff[] staffMembers = new Staff[]
{
    new Manager("Ilyas Ghanimi", 101),
    new Worker("Bob Paul", 102),
    new Worker("Charlie Smith", 103),
    new Manager("Diana Wilson", 104)
};

Film[] films = new Film[]
{
    new Film("Gladiator", 120, "18"),
    new Film("Iron Man", 150, "12"),
    new Film("Mufasa", 150, "U"),
    new Film("Maze Runner", 130, "15"),
    new Film("Holiday", 120, "12")
};

Screening[] screenings = new Screening[]
{
    new Screening(new Film("Gladiator", 120, "18"), new DateTime(2025, 8, 23, 18, 0, 0), 2, 50),
    new Screening(new Film("Iron Man", 150, "12"), new DateTime(2025, 8, 23, 20, 0, 0), 3, 30),
    new Screening(new Film("Mufasa", 150, "U"), new DateTime(2025, 8, 23, 14, 0, 0), 4, 40),
    new Screening(new Film("Maze Runner", 130, "15"), new DateTime(2025, 8, 24, 16, 0, 0), 5, 20),
    new Screening(new Film("Holiday", 120, "12"), new DateTime(2025, 8, 24, 18, 0, 0), 6, 25)
};

Concession[] concessions = new Concession[]
{
    new Concession("Popcorn", 500),
    new Concession("Soda", 300),
    new Concession("Candy", 200),
    new Concession("Nachos", 700)
};

Ticket[] tickets = new Ticket[]
{
    new Ticket("Adult", 1200),
    new Ticket("Child", 800),
    new Ticket("Premium Adult", 1800),
    new Ticket("Premium Child", 1200)
};

Capstone.Transaction transaction = new Capstone.Transaction();



Cinema cinema = new Cinema(films, concessions, tickets);


SelectStaffMenu menu = new SelectStaffMenu(staffMembers, screenings, transaction);

menu.Select();

