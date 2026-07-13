namespace OOPPart1App;

// Represents a bank account and handles deposits, withdrawals, balance checks, and account-related operations.
class BankAccount
{
    public int AccountNumber { get; set; }
    public string HolderName { get; set; }
    public double Balance { get; set; }

    public BankAccount(int accountNumber, string holderName, double startingBalance)
    {
        AccountNumber = accountNumber;
        HolderName = holderName;
        Balance = startingBalance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            SendEmail();
        }
        else
        {
            Console.WriteLine("Deposit amount must be greater than zero.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be greater than zero.");
        }
        else if (Balance >= amount)
        {
            Balance -= amount;
            SendEmail();
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }

    public double CheckBalance()
    {
        PrintInformation();
        return Balance;
    }

    public bool IsOverdrawn
    {
        get { return Balance < 0; }
    }

    private void PrintInformation()
    {
        Console.WriteLine($"Holder Name: {HolderName}");
        Console.WriteLine($"Balance: {Balance:F2}");
    }

    private void SendEmail()
    {
        Console.WriteLine("Email notification sent.");
    }
}
// Represents a student and manages student information, registration, student count, and security PIN.
class Student
{
    public int Grade { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    private string email;
    int age;

    private int securityPin;

    public static int StudentCount;

    public Student()
    {
        StudentCount++;
    }

    public void Register(string emailAddress)
    {
        email = emailAddress;
        SendEmail();
    }

    public static int GetStudentCount()
    {
        return StudentCount;
    }

    public int SecurityPin
    {
        set
        {
            if (value >= 1000 && value <= 9999)
            {
                securityPin = value;
            }
            else
            {
                Console.WriteLine("PIN must be exactly 4 digits.");
            }
        }
    }

    private void SendEmail()
    {
        Console.WriteLine("Registration email sent.");
    }
}
// Represents a product and handles sales, restocking, stock quantity, and inventory value.
class Product
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }

    public void Sell(int quantity)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("Sale quantity must be greater than zero.");
        }
        else if (StockQuantity >= quantity)
        {
            StockQuantity -= quantity;
            LogTransaction();
        }
        else
        {
            Console.WriteLine("Not enough stock.");
            LogTransaction();
        }
    }

    public void Restock(int quantity)
    {
        if (quantity > 0)
        {
            StockQuantity += quantity;
            LogTransaction();
        }
        else
        {
            Console.WriteLine("Restock quantity must be greater than zero.");
        }
    }

    public double GetInventoryValue()
    {
        PrintDetails();
        return Price * StockQuantity;
    }

    private void PrintDetails()
    {
        Console.WriteLine($"Product Name: {ProductName}");
        Console.WriteLine($"Price: {Price:F3}");
        Console.WriteLine($"Stock Quantity: {StockQuantity}");
    }

    private void LogTransaction()
    {
        Console.WriteLine("Transaction logged.");
    }
}
class Program
{
    static void Main(string[] args)
    {
static void Main(string[] args)
{
    // Creates the required BankAccount, Student, and Product objects.

    BankAccount account1 = new BankAccount(1163, "Karim", 120);
    BankAccount account2 = new BankAccount(15203, "Ali", 63);

    Student student1 = new Student();
    student1.Name = "Ali";
    student1.Address = "Muscat";
    student1.Grade = 65;

    Student student2 = new Student();
    student2.Name = "Ahmed";
    student2.Address = "Muscat";
    student2.Grade = 70;

    Product product1 = new Product();
    product1.ProductName = "Wireless Mouse";
    product1.Price = 5.500;
    product1.StockQuantity = 50;

    Product product2 = new Product();
    product2.ProductName = "Mechanical Keyboard";
    product2.Price = 15.750;
    product2.StockQuantity = 20;

    bool exitApp = false;

    while (!exitApp)
    {
        Console.WriteLine("\n===== OOP Management System =====");
        Console.WriteLine("1. View Account Details");
        Console.WriteLine("2. Update Student Address");
        Console.WriteLine("3. Make a Deposit");
        Console.WriteLine("4. Make a Withdrawal");
        Console.WriteLine("5. View Product Details");
        Console.WriteLine("6. Register a Student");
        Console.WriteLine("7. Compare Two Account Balances");
        Console.WriteLine("8. Restock Product and Check Stock Level");
        Console.WriteLine("9. Transfer Between Accounts");
        Console.WriteLine("10. Update Student Grade");
        Console.WriteLine("11. Student Report Card");
        Console.WriteLine("12. Account Health Status");
        Console.WriteLine("13. Bulk Sale With Revenue Calculation");
        Console.WriteLine("14. Scholarship Eligibility Check");
        Console.WriteLine("15. Full Balance Top-Up Flow");
        Console.WriteLine("16. Quick Account Opening");
        Console.WriteLine("17. Total Students Counter");
        Console.WriteLine("18. Overdrawn Account Check");
        Console.WriteLine("19. Set Student Security PIN");
        Console.WriteLine("20. Exit");
        Console.Write("Choose an option: ");

        int choice;

        try
        {
            choice = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input. Please enter a number from 1 to 20.");
            continue;
        }

        switch (choice)
        {
            case 1:
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;

            case 6:
                break;

            case 7:
                break;

            case 8:
                break;

            case 9:
                break;

            case 10:
                break;

            case 11:
                break;

            case 12:
                break;

            case 13:
                break;

            case 14:
                break;

            case 15:
                break;

            case 16:
                break;

            case 17:
                break;

            case 18:
                break;

            case 19:
                break;

            case 20:
                exitApp = true;
                Console.WriteLine("Thank you. Goodbye!");
                break;

            default:
                Console.WriteLine("Invalid option. Please choose between 1 and 20.");
                break;
        }
    }
}
    }
}