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
        Console.WriteLine("Hello, World!");
    }
}