using System;

namespace OOPPart1App;

// Represents a bank account and manages deposits, withdrawals, and balance information.
class BankAccount
{
    public int AccountNumber { get; set; }
    public string HolderName { get; set; } = "";
    public double Balance { get; set; }

    // Parameterized constructor initializes all account details.
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

    // Read-only property checks whether the balance is below zero.
    public bool IsOverdrawn
    {
        get
        {
            return Balance < 0;
        }
    }

    private void PrintInformation()
    {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Holder Name: {HolderName}");
        Console.WriteLine($"Balance: {Balance:F2}");
    }

    private void SendEmail()
    {
        Console.WriteLine("Email notification sent.");
    }
}

// Represents a student and manages registration, information, student count, and security PIN.
class Student
{
    public int Grade { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";

    private string email = "";
    int age;
    private int securityPin;

    public static int StudentCount;

    // Default constructor increases the total student count.
    public Student()
    {
        StudentCount++;
        age = 0;
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

    // Write-only property stores a valid 4-digit security PIN.
    public int SecurityPin
    {
        set
        {
            if (value >= 1000 && value <= 9999)
            {
                securityPin = value;
                Console.WriteLine("Security PIN was set successfully.");
            }
            else
            {
                Console.WriteLine("PIN must be exactly 4 digits.");
            }
        }
    }

    private void SendEmail()
    {
        if (email != "" && age >= 0)
        {
            Console.WriteLine("Registration email sent.");
        }
    }
}

// Represents a product and manages sales, restocking, and inventory value.
class Product
{
    public string ProductName { get; set; } = "";
    public double Price { get; set; }
    public int StockQuantity { get; set; }

    public void Sell(int quantity)
    {
        // Validates the sale and logs every transaction attempt.
        if (quantity <= 0)
        {
            Console.WriteLine("Sale quantity must be greater than zero.");
        }
        else if (StockQuantity >= quantity)
        {
            StockQuantity -= quantity;
        }
        else
        {
            Console.WriteLine("Not enough stock.");
        }

        LogTransaction();
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
        // Creates the required two accounts, two students, and two products.

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

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number from 1 to 20.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    // Lets the user choose an account and view its details.

                    Console.Write("Choose account (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int accountChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (accountChoice == 1)
                    {
                        account1.CheckBalance();
                    }
                    else if (accountChoice == 2)
                    {
                        account2.CheckBalance();
                    }
                    else
                    {
                        Console.WriteLine("Invalid account choice.");
                    }

                    break;

                case 2:
                    // Lets the user choose a student and update their address.

                    Console.Write("Choose student (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int addressStudentChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (addressStudentChoice != 1 && addressStudentChoice != 2)
                    {
                        Console.WriteLine("Invalid student choice.");
                        break;
                    }

                    Console.Write("Enter the new address: ");
                    string newAddress = Console.ReadLine();

                    if (newAddress == null || newAddress == "")
                    {
                        Console.WriteLine("Address cannot be empty.");
                    }
                    else if (addressStudentChoice == 1)
                    {
                        student1.Address = newAddress;
                        Console.WriteLine($"Address updated to: {student1.Address}");
                    }
                    else
                    {
                        student2.Address = newAddress;
                        Console.WriteLine($"Address updated to: {student2.Address}");
                    }

                    break;

                case 3:
                    // Lets the user choose an account and deposit money.

                    Console.Write("Choose account (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int depositAccountChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (depositAccountChoice != 1 && depositAccountChoice != 2)
                    {
                        Console.WriteLine("Invalid account choice.");
                        break;
                    }

                    Console.Write("Enter deposit amount: ");

                    if (!double.TryParse(Console.ReadLine(), out double depositAmount))
                    {
                        Console.WriteLine("Invalid amount.");
                        break;
                    }

                    if (depositAmount <= 0)
                    {
                        Console.WriteLine("Deposit amount must be greater than zero.");
                    }
                    else if (depositAccountChoice == 1)
                    {
                        account1.Deposit(depositAmount);
                        Console.WriteLine($"Account Holder: {account1.HolderName}");
                        Console.WriteLine($"Updated Balance: {account1.Balance:F2}");
                    }
                    else
                    {
                        account2.Deposit(depositAmount);
                        Console.WriteLine($"Account Holder: {account2.HolderName}");
                        Console.WriteLine($"Updated Balance: {account2.Balance:F2}");
                    }

                    break;

                case 4:
                    // Lets the user choose an account and withdraw money.

                    Console.Write("Choose account (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int withdrawalAccountChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (withdrawalAccountChoice != 1 && withdrawalAccountChoice != 2)
                    {
                        Console.WriteLine("Invalid account choice.");
                        break;
                    }

                    Console.Write("Enter withdrawal amount: ");

                    if (!double.TryParse(Console.ReadLine(), out double withdrawalAmount))
                    {
                        Console.WriteLine("Invalid amount.");
                        break;
                    }

                    if (withdrawalAccountChoice == 1)
                    {
                        account1.Withdraw(withdrawalAmount);
                        Console.WriteLine($"Updated Balance: {account1.Balance:F2}");
                    }
                    else
                    {
                        account2.Withdraw(withdrawalAmount);
                        Console.WriteLine($"Updated Balance: {account2.Balance:F2}");
                    }

                    break;

                case 5:
                    // Lets the user choose a product and view its inventory details.

                    Console.Write("Choose product (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int productChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (productChoice == 1)
                    {
                        double inventoryValue = product1.GetInventoryValue();
                        Console.WriteLine($"Total Inventory Value: {inventoryValue:F3}");
                    }
                    else if (productChoice == 2)
                    {
                        double inventoryValue = product2.GetInventoryValue();
                        Console.WriteLine($"Total Inventory Value: {inventoryValue:F3}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid product choice.");
                    }

                    break;

                case 6:
                    // Lets the user register a selected student through the public Register method.

                    Console.Write("Choose student (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int registerStudentChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (registerStudentChoice != 1 && registerStudentChoice != 2)
                    {
                        Console.WriteLine("Invalid student choice.");
                        break;
                    }

                    Console.Write("Enter student email: ");
                    string studentEmail = Console.ReadLine();

                    if (studentEmail == null || studentEmail == "")
                    {
                        Console.WriteLine("Email cannot be empty.");
                    }
                    else if (registerStudentChoice == 1)
                    {
                        student1.Register(studentEmail);
                        Console.WriteLine("Student registered successfully.");
                    }
                    else
                    {
                        student2.Register(studentEmail);
                        Console.WriteLine("Student registered successfully.");
                    }

                    break;

                case 7:
                    // Compares the balances of the two bank accounts.

                    if (account1.Balance > account2.Balance)
                    {
                        Console.WriteLine($"{account1.HolderName}'s account has more money.");
                    }
                    else if (account2.Balance > account1.Balance)
                    {
                        Console.WriteLine($"{account2.HolderName}'s account has more money.");
                    }
                    else
                    {
                        Console.WriteLine("Both accounts have the same balance.");
                    }

                    break;

                case 8:
                    // Restocks a product and displays its new stock level.

                    Console.Write("Choose product (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int restockProductChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (restockProductChoice != 1 && restockProductChoice != 2)
                    {
                        Console.WriteLine("Invalid product choice.");
                        break;
                    }

                    Console.Write("Enter quantity to restock: ");

                    if (!int.TryParse(Console.ReadLine(), out int restockQuantity))
                    {
                        Console.WriteLine("Invalid quantity.");
                        break;
                    }

                    if (restockQuantity <= 0)
                    {
                        Console.WriteLine("Restock quantity must be greater than zero.");
                        break;
                    }

                    int updatedStock;

                    if (restockProductChoice == 1)
                    {
                        product1.Restock(restockQuantity);
                        updatedStock = product1.StockQuantity;
                    }
                    else
                    {
                        product2.Restock(restockQuantity);
                        updatedStock = product2.StockQuantity;
                    }

                    if (updatedStock < 10)
                    {
                        Console.WriteLine("Stock Level: Low");
                    }
                    else if (updatedStock < 50)
                    {
                        Console.WriteLine("Stock Level: Moderate");
                    }
                    else
                    {
                        Console.WriteLine("Stock Level: Well Stocked");
                    }

                    break;

                case 9:
                    // Transfers money between the two accounts after validating the source balance.

                    Console.Write("Choose source account (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int sourceAccountChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    Console.Write("Choose destination account (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int destinationAccountChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if ((sourceAccountChoice != 1 && sourceAccountChoice != 2) ||
                        (destinationAccountChoice != 1 && destinationAccountChoice != 2))
                    {
                        Console.WriteLine("Invalid account choice.");
                        break;
                    }

                    if (sourceAccountChoice == destinationAccountChoice)
                    {
                        Console.WriteLine("Source and destination accounts must be different.");
                        break;
                    }

                    Console.Write("Enter transfer amount: ");

                    if (!double.TryParse(Console.ReadLine(), out double transferAmount))
                    {
                        Console.WriteLine("Invalid amount.");
                        break;
                    }

                    if (transferAmount <= 0)
                    {
                        Console.WriteLine("Transfer amount must be greater than zero.");
                    }
                    else if (sourceAccountChoice == 1)
                    {
                        if (account1.Balance >= transferAmount)
                        {
                            account1.Withdraw(transferAmount);
                            account2.Deposit(transferAmount);
                            Console.WriteLine("Transfer completed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Transfer failed. Insufficient balance.");
                        }
                    }
                    else
                    {
                        if (account2.Balance >= transferAmount)
                        {
                            account2.Withdraw(transferAmount);
                            account1.Deposit(transferAmount);
                            Console.WriteLine("Transfer completed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Transfer failed. Insufficient balance.");
                        }
                    }

                    Console.WriteLine($"{account1.HolderName} Balance: {account1.Balance:F2}");
                    Console.WriteLine($"{account2.HolderName} Balance: {account2.Balance:F2}");

                    break;

                case 10:
                    // Updates a student's grade only when the value is between 0 and 100.

                    Console.Write("Choose student (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int gradeStudentChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (gradeStudentChoice != 1 && gradeStudentChoice != 2)
                    {
                        Console.WriteLine("Invalid student choice.");
                        break;
                    }

                    Console.Write("Enter the new grade: ");

                    if (!int.TryParse(Console.ReadLine(), out int newGrade))
                    {
                        Console.WriteLine("Invalid grade. Please enter a number.");
                    }
                    else if (newGrade < 0 || newGrade > 100)
                    {
                        Console.WriteLine("Grade must be between 0 and 100.");
                    }
                    else if (gradeStudentChoice == 1)
                    {
                        student1.Grade = newGrade;
                        Console.WriteLine($"Grade updated successfully to: {student1.Grade}");
                    }
                    else
                    {
                        student2.Grade = newGrade;
                        Console.WriteLine($"Grade updated successfully to: {student2.Grade}");
                    }

                    break;

                case 11:
                    // Displays the selected student's report card and Pass or Fail result.

                    Console.Write("Choose student (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int reportStudentChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (reportStudentChoice == 1)
                    {
                        string result;

                        if (student1.Grade >= 60)
                        {
                            result = "Pass";
                        }
                        else
                        {
                            result = "Fail";
                        }

                        Console.WriteLine("\n===== Student Report Card =====");
                        Console.WriteLine($"Name: {student1.Name}");
                        Console.WriteLine($"Address: {student1.Address}");
                        Console.WriteLine($"Grade: {student1.Grade}");
                        Console.WriteLine($"Result: {result}");
                    }
                    else if (reportStudentChoice == 2)
                    {
                        string result;

                        if (student2.Grade >= 60)
                        {
                            result = "Pass";
                        }
                        else
                        {
                            result = "Fail";
                        }

                        Console.WriteLine("\n===== Student Report Card =====");
                        Console.WriteLine($"Name: {student2.Name}");
                        Console.WriteLine($"Address: {student2.Address}");
                        Console.WriteLine($"Grade: {student2.Grade}");
                        Console.WriteLine($"Result: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid student choice.");
                    }

                    break;

                case 12:
                    // Displays the health status of a selected bank account.

                    Console.Write("Choose account (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int healthAccountChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    double healthBalance;

                    if (healthAccountChoice == 1)
                    {
                        healthBalance = account1.Balance;
                    }
                    else if (healthAccountChoice == 2)
                    {
                        healthBalance = account2.Balance;
                    }
                    else
                    {
                        Console.WriteLine("Invalid account choice.");
                        break;
                    }

                    if (healthBalance < 50)
                    {
                        Console.WriteLine("Account Status: Low Balance");
                    }
                    else if (healthBalance <= 1000)
                    {
                        Console.WriteLine("Account Status: Healthy");
                    }
                    else
                    {
                        Console.WriteLine("Account Status: Premium");
                    }

                    break;

                case 13:
                    // Processes a bulk sale and calculates its total revenue.

                    Console.Write("Choose product (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int saleProductChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (saleProductChoice != 1 && saleProductChoice != 2)
                    {
                        Console.WriteLine("Invalid product choice.");
                        break;
                    }

                    Console.Write("Enter quantity to sell: ");

                    if (!int.TryParse(Console.ReadLine(), out int saleQuantity))
                    {
                        Console.WriteLine("Invalid quantity.");
                        break;
                    }

                    if (saleQuantity <= 0)
                    {
                        Console.WriteLine("Sale quantity must be greater than zero.");
                    }
                    else if (saleProductChoice == 1)
                    {
                        if (product1.StockQuantity < saleQuantity)
                        {
                            int additionalUnitsNeeded =
                                saleQuantity - product1.StockQuantity;

                            Console.WriteLine(
                                $"Not enough stock. Additional units needed: {additionalUnitsNeeded}"
                            );
                        }
                        else
                        {
                            product1.Sell(saleQuantity);

                            double totalRevenue = saleQuantity * product1.Price;
                            Console.WriteLine($"Total Revenue: {totalRevenue:F3}");
                        }
                    }
                    else
                    {
                        if (product2.StockQuantity < saleQuantity)
                        {
                            int additionalUnitsNeeded =
                                saleQuantity - product2.StockQuantity;

                            Console.WriteLine(
                                $"Not enough stock. Additional units needed: {additionalUnitsNeeded}"
                            );
                        }
                        else
                        {
                            product2.Sell(saleQuantity);

                            double totalRevenue = saleQuantity * product2.Price;
                            Console.WriteLine($"Total Revenue: {totalRevenue:F3}");
                        }
                    }

                    break;

                case 14:
                    // Checks scholarship eligibility using a student's grade and an account balance.

                    Console.Write("Choose student (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int scholarshipStudentChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    Console.Write("Choose account (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int scholarshipAccountChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    int selectedGrade;
                    double selectedBalance;

                    if (scholarshipStudentChoice == 1)
                    {
                        selectedGrade = student1.Grade;
                    }
                    else if (scholarshipStudentChoice == 2)
                    {
                        selectedGrade = student2.Grade;
                    }
                    else
                    {
                        Console.WriteLine("Invalid student choice.");
                        break;
                    }

                    if (scholarshipAccountChoice == 1)
                    {
                        selectedBalance = account1.Balance;
                    }
                    else if (scholarshipAccountChoice == 2)
                    {
                        selectedBalance = account2.Balance;
                    }
                    else
                    {
                        Console.WriteLine("Invalid account choice.");
                        break;
                    }

                    if (selectedGrade >= 80 && selectedBalance >= 100)
                    {
                        Console.WriteLine("Eligible");
                    }
                    else
                    {
                        Console.WriteLine("Not Eligible");

                        if (selectedGrade < 80)
                        {
                            Console.WriteLine("Reason: Student grade is below 80.");
                        }

                        if (selectedBalance < 100)
                        {
                            Console.WriteLine("Reason: Account balance is below 100.");
                        }
                    }

                    break;

                case 15:
                    // Tops up a selected account to 100 when its balance is below 50.

                    Console.Write("Choose account (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int topUpAccountChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (topUpAccountChoice == 1)
                    {
                        double balanceBefore = account1.Balance;

                        if (balanceBefore < 50)
                        {
                            double topUpAmount = 100 - balanceBefore;
                            account1.Deposit(topUpAmount);

                            Console.WriteLine($"Balance Before: {balanceBefore:F2}");
                            Console.WriteLine($"Top-Up Amount: {topUpAmount:F2}");
                            Console.WriteLine($"Balance After: {account1.Balance:F2}");
                        }
                        else
                        {
                            Console.WriteLine("No top-up is needed.");
                        }
                    }
                    else if (topUpAccountChoice == 2)
                    {
                        double balanceBefore = account2.Balance;

                        if (balanceBefore < 50)
                        {
                            double topUpAmount = 100 - balanceBefore;
                            account2.Deposit(topUpAmount);

                            Console.WriteLine($"Balance Before: {balanceBefore:F2}");
                            Console.WriteLine($"Top-Up Amount: {topUpAmount:F2}");
                            Console.WriteLine($"Balance After: {account2.Balance:F2}");
                        }
                        else
                        {
                            Console.WriteLine("No top-up is needed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid account choice.");
                    }

                    break;

                case 16:
                    // Creates a new account using only the parameterized constructor.

                    Console.Write("Enter account number: ");

                    if (!int.TryParse(Console.ReadLine(), out int newAccountNumber))
                    {
                        Console.WriteLine("Invalid account number.");
                        break;
                    }

                    Console.Write("Enter holder name: ");
                    string newHolderName = Console.ReadLine();

                    if (newHolderName == null || newHolderName == "")
                    {
                        Console.WriteLine("Holder name cannot be empty.");
                        break;
                    }

                    Console.Write("Enter starting balance: ");

                    if (!double.TryParse(Console.ReadLine(), out double newStartingBalance))
                    {
                        Console.WriteLine("Invalid starting balance.");
                        break;
                    }

                    if (newStartingBalance < 0)
                    {
                        Console.WriteLine("Starting balance cannot be negative.");
                        break;
                    }

                    BankAccount newAccount = new BankAccount(
                        newAccountNumber,
                        newHolderName,
                        newStartingBalance
                    );

                    Console.WriteLine("Account created successfully.");
                    newAccount.CheckBalance();

                    break;

                case 17:
                    // Displays the number of Student objects using a static method.

                    int totalStudents = Student.GetStudentCount();
                    Console.WriteLine($"Total Students Created: {totalStudents}");

                    break;

                case 18:
                    // Checks whether a selected account is overdrawn using a read-only property.

                    Console.Write("Choose account (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int overdrawnAccountChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (overdrawnAccountChoice == 1)
                    {
                        if (account1.IsOverdrawn)
                        {
                            Console.WriteLine("The account is overdrawn.");
                        }
                        else
                        {
                            Console.WriteLine("The account is not overdrawn.");
                        }
                    }
                    else if (overdrawnAccountChoice == 2)
                    {
                        if (account2.IsOverdrawn)
                        {
                            Console.WriteLine("The account is overdrawn.");
                        }
                        else
                        {
                            Console.WriteLine("The account is not overdrawn.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid account choice.");
                    }

                    break;

                case 19:
                    // Sets a valid 4-digit PIN using the Student write-only property.

                    Console.Write("Choose student (1 or 2): ");

                    if (!int.TryParse(Console.ReadLine(), out int pinStudentChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    if (pinStudentChoice != 1 && pinStudentChoice != 2)
                    {
                        Console.WriteLine("Invalid student choice.");
                        break;
                    }

                    Console.Write("Enter a 4-digit PIN: ");

                    if (!int.TryParse(Console.ReadLine(), out int studentPin))
                    {
                        Console.WriteLine("Invalid PIN. Please enter numbers only.");
                        break;
                    }

                    if (studentPin < 1000 || studentPin > 9999)
                    {
                        Console.WriteLine("PIN must be exactly 4 digits.");
                        break;
                    }

                    if (pinStudentChoice == 1)
                    {
                        student1.SecurityPin = studentPin;
                    }
                    else
                    {
                        student2.SecurityPin = studentPin;
                    }

                    break;

                case 20:
                    // Exits the application and stops the menu loop.

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