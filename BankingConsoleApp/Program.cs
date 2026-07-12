using System;
using System.Collections.Generic;

namespace BankingConsoleApp;

class Program
{
    static List<string> customerNames = new List<string>();
    static List<string> accountNumbers = new List<string>();
    static List<double> balances = new List<double>();

    static void Main(string[] args)
    {
        bool exitApp = false;

        while (!exitApp)
        {
            Console.WriteLine("\n===== Welcome to Spark Bank =====");
            Console.WriteLine("1. Add New Account");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Show Balance");
            Console.WriteLine("5. Transfer Amount");
            Console.WriteLine("6. List All Accounts");
            Console.WriteLine("7. Search Accounts by Customer Name");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");

            int choice;

            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddAccount();
                    break;

                case 2:
                    DepositMoney();
                    break;

                case 3:
                    WithdrawMoney();
                    break;

                case 4:
                    ShowBalance();
                    break;

                case 5:
                    TransferAmount();
                    break;

                case 6:
                    ListAllAccounts();
                    break;

                case 7:
                    SearchAccountsByCustomerName();
                    break;

                case 8:
                    exitApp = true;
                    Console.WriteLine("Thank you for banking with Spark Bank. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option, please choose between 1 and 8.");
                    break;
            }
        }
    }

    static void AddAccount()
    {
        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine();

        Console.Write("Enter account number: ");
        string accountNumber = Console.ReadLine();

        if (accountNumbers.Contains(accountNumber))
        {
            Console.WriteLine("Error: This account number already exists.");
            return;
        }

        Console.Write("Enter initial deposit amount: ");

        double initialDeposit;

        try
        {
            initialDeposit = double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input. Please enter a valid amount.");
            return;
        }

        if (initialDeposit < 0)
        {
            Console.WriteLine("Error: Initial deposit cannot be negative.");
            return;
        }

        customerNames.Add(customerName);
        accountNumbers.Add(accountNumber);
        balances.Add(initialDeposit);

        Console.WriteLine("\nAccount created successfully!");
        Console.WriteLine($"Customer Name: {customerName}");
        Console.WriteLine($"Account Number: {accountNumber}");
        Console.WriteLine($"Starting Balance: {initialDeposit:F2}");
    }

    static void DepositMoney()
    {
        Console.Write("Enter account number: ");
        string accountNumber = Console.ReadLine();

        int index = accountNumbers.IndexOf(accountNumber);

        if (index == -1)
        {
            Console.WriteLine("Account not found.");
            return;
        }
        Console.Write("Enter deposit amount: ");

        double amount;

        try
        {
            amount = double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid amount.");
            return;
        }

        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be greater than zero.");
            return;
        }

        balances[index] += amount;

        Console.WriteLine($"Deposit successful.");
        Console.WriteLine($"New Balance: {balances[index]:F2}");
    }

    static void WithdrawMoney()
    
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            int index = accountNumbers.IndexOf(accountNumber);

            if (index == -1)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.Write("Enter withdrawal amount: ");

            double amount;

            try
            {
                amount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
                return;
            }

            if (amount > balances[index])
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            balances[index] -= amount;

            Console.WriteLine("Withdrawal successful.");
            Console.WriteLine($"New Balance: {balances[index]:F2}");
        }
    

    static void ShowBalance()
    {
        // TODO
    }

    static void TransferAmount()
    {
        // TODO
    }

    static void ListAllAccounts()
    {
        // TODO
    }

    static void SearchAccountsByCustomerName()
    {
        // TODO
    }
}