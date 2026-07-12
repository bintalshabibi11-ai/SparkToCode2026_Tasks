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
        // TODO
    }

    static void DepositMoney()
    {
        // TODO
    }

    static void WithdrawMoney()
    {
        // TODO
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