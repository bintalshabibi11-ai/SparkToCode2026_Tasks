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
                // user choose one of the two bank accounts and view its details.

                Console.Write("Choose account (1 or 2): ");
                int accountChoice = int.Parse(Console.ReadLine());

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
                // user choose a student and update their address.

                Console.Write("Choose student (1 or 2): ");
                int studentChoice = int.Parse(Console.ReadLine());

                Console.Write("Enter the new address: ");
                string newAddress = Console.ReadLine();

                if (studentChoice == 1)
                {
                    student1.Address = newAddress;
                    Console.WriteLine($"Address updated to: {student1.Address}");
                }
                else if (studentChoice == 2)
                {
                    student2.Address = newAddress;
                    Console.WriteLine($"Address updated to: {student2.Address}");
                }
                else
                {
                    Console.WriteLine("Invalid student choice.");
                }

                break;

            case 3:
                // user choose a bank account and deposit money into it.

                Console.Write("Choose account (1 or 2): ");
                int depositAccountChoice = int.Parse(Console.ReadLine());

                Console.Write("Enter deposit amount: ");
                double depositAmount = double.Parse(Console.ReadLine());

                if (depositAccountChoice == 1)
                {
                    account1.Deposit(depositAmount);
                    Console.WriteLine($"Account Holder: {account1.HolderName}");
                    Console.WriteLine($"Updated Balance: {account1.Balance:F2}");
                }
                else if (depositAccountChoice == 2)
                {
                    account2.Deposit(depositAmount);
                    Console.WriteLine($"Account Holder: {account2.HolderName}");
                    Console.WriteLine($"Updated Balance: {account2.Balance:F2}");
                }
                else
                {
                    Console.WriteLine("Invalid account choice.");
                }

                break;

            case 4:
                // user choose a bank account and withdraw money from it.

                Console.Write("Choose account (1 or 2): ");
                int withdrawalAccountChoice = int.Parse(Console.ReadLine());

                Console.Write("Enter withdrawal amount: ");
                double withdrawalAmount = double.Parse(Console.ReadLine());

                if (withdrawalAccountChoice == 1)
                {
                    account1.Withdraw(withdrawalAmount);
                    Console.WriteLine($"Updated Balance: {account1.Balance:F2}");
                }
                else if (withdrawalAccountChoice == 2)
                {
                    account2.Withdraw(withdrawalAmount);
                    Console.WriteLine($"Updated Balance: {account2.Balance:F2}");
                }
                else
                {
                    Console.WriteLine("Invalid account choice.");
                }

                break;

            case 5:
                // user choose a product and view its details and total inventory value.

                Console.Write("Choose product (1 or 2): ");
                int productChoice = int.Parse(Console.ReadLine());

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
                // user choose a student and register them using an email address.

                Console.Write("Choose student (1 or 2): ");
                int registerStudentChoice = int.Parse(Console.ReadLine());

                Console.Write("Enter student email: ");
                string studentEmail = Console.ReadLine();

                if (registerStudentChoice == 1)
                {
                    student1.Register(studentEmail);
                    Console.WriteLine("Student registered successfully.");
                }
                else if (registerStudentChoice == 2)
                {
                    student2.Register(studentEmail);
                    Console.WriteLine("Student registered successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid student choice.");
                }

                break;

            case 7:
                // Compares the balances of the two bank accounts and shows which account has more money.

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
                // Restocks a selected product and checks whether its stock level is low, moderate, or well stocked.

                Console.Write("Choose product (1 or 2): ");
                int restockProductChoice = int.Parse(Console.ReadLine());

                Console.Write("Enter quantity to restock: ");
                int restockQuantity = int.Parse(Console.ReadLine());

                if (restockProductChoice == 1)
                {
                    product1.Restock(restockQuantity);

                    if (product1.StockQuantity < 10)
                    {
                        Console.WriteLine("Stock Level: Low");
                    }
                    else if (product1.StockQuantity < 50)
                    {
                        Console.WriteLine("Stock Level: Moderate");
                    }
                    else
                    {
                        Console.WriteLine("Stock Level: Well Stocked");
                    }
                }
                else if (restockProductChoice == 2)
                {
                    product2.Restock(restockQuantity);

                    if (product2.StockQuantity < 10)
                    {
                        Console.WriteLine("Stock Level: Low");
                    }
                    else if (product2.StockQuantity < 50)
                    {
                        Console.WriteLine("Stock Level: Moderate");
                    }
                    else
                    {
                        Console.WriteLine("Stock Level: Well Stocked");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product choice.");
                }

                break;

            case 9: 
                // Transfers money between the two bank accounts after checking that the source account has enough balance.

                Console.Write("Choose source account (1 or 2): ");
                int sourceAccountChoice = int.Parse(Console.ReadLine());

                Console.Write("Choose destination account (1 or 2): ");
                int destinationAccountChoice = int.Parse(Console.ReadLine());

                Console.Write("Enter transfer amount: ");
                double transferAmount = double.Parse(Console.ReadLine());

                if (sourceAccountChoice == destinationAccountChoice)
                {
                    Console.WriteLine("Source and destination accounts must be different.");
                }
                else if (sourceAccountChoice == 1 && destinationAccountChoice == 2)
                {
                    if (account1.Balance >= transferAmount && transferAmount > 0)
                    {
                        account1.Withdraw(transferAmount);
                        account2.Deposit(transferAmount);

                        Console.WriteLine("Transfer completed successfully.");
                        Console.WriteLine($"{account1.HolderName} Balance: {account1.Balance:F2}");
                        Console.WriteLine($"{account2.HolderName} Balance: {account2.Balance:F2}");
                    }
                    else
                    {
                        Console.WriteLine("Transfer failed. Insufficient balance or invalid amount.");
                    }
                }
                else if (sourceAccountChoice == 2 && destinationAccountChoice == 1)
                {
                    if (account2.Balance >= transferAmount && transferAmount > 0)
                    {
                        account2.Withdraw(transferAmount);
                        account1.Deposit(transferAmount);

                        Console.WriteLine("Transfer completed successfully.");
                        Console.WriteLine($"{account2.HolderName} Balance: {account2.Balance:F2}");
                        Console.WriteLine($"{account1.HolderName} Balance: {account1.Balance:F2}");
                    }
                    else
                    {
                        Console.WriteLine("Transfer failed. Insufficient balance or invalid amount.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid account choice.");
                }

                break;

            case 10:
                // Updates a selected student's grade only if the entered value is a valid number from 0 to 100.

                Console.Write("Choose student (1 or 2): ");
                int gradeStudentChoice = int.Parse(Console.ReadLine());

                Console.Write("Enter the new grade: ");
                string gradeInput = Console.ReadLine();

                if (!int.TryParse(gradeInput, out int newGrade))
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
                else if (gradeStudentChoice == 2)
                {
                    student2.Grade = newGrade;
                    Console.WriteLine($"Grade updated successfully to: {student2.Grade}");
                }
                else
                {
                    Console.WriteLine("Invalid student choice.");
                }

                break;

            case 11:
                // Displays a selected student's report card and calculates whether the student passed or failed.

                Console.Write("Choose student (1 or 2): ");
                int reportStudentChoice = int.Parse(Console.ReadLine());

                if (reportStudentChoice == 1)
                {
                    string result = student1.Grade >= 60 ? "Pass" : "Fail";

                    Console.WriteLine("\n===== Student Report Card =====");
                    Console.WriteLine($"Name: {student1.Name}");
                    Console.WriteLine($"Address: {student1.Address}");
                    Console.WriteLine($"Grade: {student1.Grade}");
                    Console.WriteLine($"Result: {result}");
                }
                else if (reportStudentChoice == 2)
                {
                    string result = student2.Grade >= 60 ? "Pass" : "Fail";

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
                // Shows the health status of a selected bank account based on its current balance.

                Console.Write("Choose account (1 or 2): ");
                int healthAccountChoice = int.Parse(Console.ReadLine());

                if (healthAccountChoice == 1)
                {
                    if (account1.Balance < 50)
                    {
                        Console.WriteLine("Account Status: Low Balance");
                    }
                    else if (account1.Balance <= 1000)
                    {
                        Console.WriteLine("Account Status: Healthy");
                    }
                    else
                    {
                        Console.WriteLine("Account Status: Premium");
                    }
                }
                else if (healthAccountChoice == 2)
                {
                    if (account2.Balance < 50)
                    {
                        Console.WriteLine("Account Status: Low Balance");
                    }
                    else if (account2.Balance <= 1000)
                    {
                        Console.WriteLine("Account Status: Healthy");
                    }
                    else
                    {
                        Console.WriteLine("Account Status: Premium");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid account choice.");
                }

                break;

            case 13:
                // Sells a selected product in bulk and calculates the total revenue if enough stock is available.

                Console.Write("Choose product (1 or 2): ");
                int saleProductChoice = int.Parse(Console.ReadLine());

                Console.Write("Enter quantity to sell: ");
                int saleQuantity = int.Parse(Console.ReadLine());

                if (saleProductChoice == 1)
                {
                    if (saleQuantity <= 0)
                    {
                        Console.WriteLine("Sale quantity must be greater than zero.");
                    }
                    else if (product1.StockQuantity < saleQuantity)
                    {
                        int additionalUnitsNeeded = saleQuantity - product1.StockQuantity;
                        Console.WriteLine($"Not enough stock. Additional units needed: {additionalUnitsNeeded}");
                    }
                    else
                    {
                        product1.Sell(saleQuantity);

                        double totalRevenue = saleQuantity * product1.Price;
                        Console.WriteLine($"Total Revenue: {totalRevenue:F3}");
                    }
                }
                else if (saleProductChoice == 2)
                {
                    if (saleQuantity <= 0)
                    {
                        Console.WriteLine("Sale quantity must be greater than zero.");
                    }
                    else if (product2.StockQuantity < saleQuantity)
                    {
                        int additionalUnitsNeeded = saleQuantity - product2.StockQuantity;
                        Console.WriteLine($"Not enough stock. Additional units needed: {additionalUnitsNeeded}");
                    }
                    else
                    {
                        product2.Sell(saleQuantity);

                        double totalRevenue = saleQuantity * product2.Price;
                        Console.WriteLine($"Total Revenue: {totalRevenue:F3}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product choice.");
                }

                break;

            case 14:
                // Checks scholarship eligibility using a selected student's grade and a selected account's balance.

                Console.Write("Choose student (1 or 2): ");
                int scholarshipStudentChoice = int.Parse(Console.ReadLine());

                Console.Write("Choose account (1 or 2): ");
                int scholarshipAccountChoice = int.Parse(Console.ReadLine());

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
                // Tops up a selected low-balance account to exactly 100 when its balance is below 50.

                Console.Write("Choose account (1 or 2): ");
                int topUpAccountChoice = int.Parse(Console.ReadLine());

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
                // Creates a new bank account using the parameterized constructor and displays its details.

                Console.Write("Enter account number: ");
                int newAccountNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter holder name: ");
                string newHolderName = Console.ReadLine();

                Console.Write("Enter starting balance: ");
                double newStartingBalance = double.Parse(Console.ReadLine());

                BankAccount newAccount = new BankAccount(
                    newAccountNumber,
                    newHolderName,
                    newStartingBalance
                );

                Console.WriteLine("Account created successfully.");
                newAccount.CheckBalance();

                break;

            case 17:
                // Displays the total number of Student objects created using a static method.

                int totalStudents = Student.GetStudentCount();

                Console.WriteLine($"Total Students Created: {totalStudents}");

                break;

            case 18:
                // Checks whether the selected bank account is overdrawn using a read-only property.

                Console.Write("Choose account (1 or 2): ");
                int overdrawnAccountChoice = int.Parse(Console.ReadLine());

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
                // Sets a 4-digit security PIN for the selected student using a write-only property.

                Console.Write("Choose student (1 or 2): ");
                int pinStudentChoice = int.Parse(Console.ReadLine());

                Console.Write("Enter a 4-digit PIN: ");
                int studentPin = int.Parse(Console.ReadLine());

                if (pinStudentChoice == 1)
                {
                    student1.SecurityPin = studentPin;
                    Console.WriteLine("Security PIN was set successfully.");
                }
                else if (pinStudentChoice == 2)
                {
                    student2.SecurityPin = studentPin;
                    Console.WriteLine("Security PIN was set successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid student choice.");
                }

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
