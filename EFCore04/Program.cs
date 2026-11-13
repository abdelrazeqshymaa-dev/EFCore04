using EFCore04.Data;
using EFCore04.Models;
using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;
using var db = new BankdbContext();
db.Database.Migrate();
while (true)
{
    Console.Clear();
    Console.WriteLine("========================================");
    Console.WriteLine("    National Bank – Management");
    Console.WriteLine("========================================");
    Console.WriteLine("  1) Add a new Customer");
    Console.WriteLine("  2) Open a new Account for a Customer");
    Console.WriteLine("  3) Update Account Status (Active / Closed)");
    Console.WriteLine("  4) Remove an Account from a Customer");
    Console.WriteLine("  5) List all Customers (with accounts)");
    Console.WriteLine("  0) Exit");
    Console.WriteLine("----------------------------------------");
    Console.Write("  Enter choice: ");

    var choice = Console.ReadLine();
    if (choice == "0") break;

    switch (choice)
    {
        case "1": AddCustomer(); break;
        case "2": OpenAccount(); break;
        case "3": UpdateStatus(); break;
        case "4": RemoveAccount(); break;
        case "5": ListCustomers(); break;
        default: Say("Invalid choice, please enter 0-5.", ConsoleColor.Red); break;
    }
Console.WriteLine("\nPress any key to return to the menu...");
Console.ReadKey(true);
}

// ---- helpers ----
void Say(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}

string Ask(string label) { Console.Write(label + ": "); return Console.ReadLine()?.Trim() ?? ""; }

int AskInt(string label, int min = int.MinValue, int max = int.MaxValue)
{
    int n;
    Console.Write(label + ": ");
    while (!int.TryParse(Console.ReadLine(), out n) || n < min || n > max)
        Console.Write("  Invalid input, try again: ");
    return n;
}

// ---- 1 ----
void AddCustomer()
{
    Console.WriteLine("--- Add New Customer ---");
    var name = Ask("Full Name      ");
    var nid = Ask("National ID    ");
    Console.Write("Date of Birth  : (yyyy-MM-dd) ");
    DateTime dob;
    while (!DateTime.TryParse(Console.ReadLine(), out dob))
        Console.Write("  Invalid date, try again: ");
    var email = Ask("Email          ");
    var phone = Ask("Phone          ");
    var address = Ask("Address        ");
    Console.WriteLine("Customer Type:\n    1) Individual\n    2) Business");
    var type = AskInt("  Choice", 1, 2);

    if (name == "" || nid == "" || !email.Contains('@'))
    { Say("Invalid data (name, national ID and a valid email are required).", ConsoleColor.Red); return; }

    var c = new Customer
    {
        FullName = name,
        NationalId = nid,
        DateOfBirth = dob,
        Email = email,
        PhoneNumber = phone,
        Address = address,
        CustomerType = (CustomerType)type
    };
    db.Customers.Add(c);
    db.SaveChanges();
    Say($"\nCustomer created successfully. CustomerId = {c.Id}", ConsoleColor.Green);
}

// ---- 2 ----
void OpenAccount()
{
    Console.WriteLine("--- Open New Account ---");
    var accNo = Ask("Account Number ");
    Console.WriteLine("Account Type:\n    1) Savings\n    2) Current\n    3) Business");
    var accType = AskInt("  Choice", 1, 3);
    var branchCode = Ask("Branch Code    ");
    var customerId = AskInt("Customer Id    ");
    Console.WriteLine("Ownership Role:\n    1) Primary\n    2) CoHolder");
    var role = AskInt("  Choice", 1, 2);

    Say($"Validating branch '{branchCode}' and customer #{customerId}...", ConsoleColor.Cyan);
    var branch = db.Branches.FirstOrDefault(b => b.Code == branchCode);
    if (branch == null || !db.Customers.Any(c => c.Id == customerId))
    { Say("Branch or customer not found.", ConsoleColor.Red); return; }

    if (db.Accounts.Find(accNo) == null)
        db.Accounts.Add(new Account
        {
            AccountNumber = accNo,
            AccountType = (AccountType)accType,
            BranchId = branch.Id,
            OpeningDate = DateTime.Today
        });

    db.CustomerAccounts.Add(new CustomerAccount
    {
        AccountNumber = accNo,
        CustomerId = customerId,
        OwnershipType = (OwnershipType)role,
        OwnershipStartDate = DateTime.Today,
        AccountStatus = AccountStatus.Active
    });
    db.SaveChanges();
    Say($"Account '{accNo}' created and linked to customer {customerId} as {(OwnershipType)role} owner.", ConsoleColor.Green);
}

// ---- 3 ----
void UpdateStatus()
{
    Console.WriteLine("--- Update Account Status ---");
    var accNo = Ask("Account Number ");
    var customerId = AskInt("Customer Id    ");
    var link = db.CustomerAccounts.Find(customerId, accNo);
    if (link == null) { Say("Account/customer link not found.", ConsoleColor.Red); return; }

    Console.WriteLine("New Status:\n    1) Active\n    2) Closed");
    var status = AskInt("  Choice", 1, 2);
    link.AccountStatus = (AccountStatus)status;
    db.SaveChanges();
    Say($"Status updated to {link.AccountStatus}.", ConsoleColor.Green);
}

// ---- 4 ----
void RemoveAccount()
{
    Console.WriteLine("--- Remove Account From Customer ---");
    var accNo = Ask("Account Number ");
    var customerId = AskInt("Customer Id    ");
    var link = db.CustomerAccounts.Find(customerId, accNo);
    if (link == null) { Say("Account/customer link not found.", ConsoleColor.Red); return; }

    db.CustomerAccounts.Remove(link);
    db.SaveChanges();
    Say("\n  Ownership link deleted.", ConsoleColor.Green);

    if (!db.CustomerAccounts.Any(x => x.AccountNumber == accNo))
    {
        db.Accounts.Remove(db.Accounts.Find(accNo)!);
        db.SaveChanges();
        Say($"      That was the last owner – account '{accNo}' was also removed.", ConsoleColor.Cyan);
    }
}

// ---- 5 ----
void ListCustomers()
{
    Console.WriteLine("--- All Customers ---\n");
    var customers = db.Customers
        .Include(c => c.CustomerAccounts).ThenInclude(ca => ca.Account).ThenInclude(a => a.Branch)
        .ToList();

    foreach (var c in customers)
    {
        Console.WriteLine($"  #{c.Id} {c.FullName} ({c.CustomerType})");
        if (c.CustomerAccounts.Count == 0) Console.WriteLine("      (no accounts)");
        foreach (var ca in c.CustomerAccounts)
            Console.WriteLine($"      {ca.AccountNumber,-8} {ca.Account.AccountType,-9} Balance: {ca.Account.CurrentBalance,10:N2}   {ca.OwnershipType,-9} {ca.AccountStatus,-7} @ {ca.Account.Branch.Name}");
    }
}
