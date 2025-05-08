using System;

public class ExpenseTracker
{
    public class DataStore
    {
        public static int CurrentBalance = 0;
        public static int MonthlyExpense = 0;
        public static int AvailableBalance
        {
            get { return CurrentBalance - MonthlyExpense; }
        }


    }

    public class Login
    {
        //Hardcoded user credentials for login
        string[,] users = {
            { "fahim", "test12" },
            { "hamza", "pass123" },
            {"huma","word123"}
        };
        public string userName;
        public string password;
        public bool Authenticate()
        {
            for (int i = 0; i < users.GetLength(0); i++)
            {
                if (users[i, 0] == userName.ToLower() && users[i, 1] == password)
                    return true;
            }
            return false;
        }

    }

    public class Transaction : Login
    {

        private int deposit = 0;
        public void info()
        {
            Console.WriteLine("Successfully Logged! Welcome, " + userName.ToUpper());
        }
        public void depositAmount()
        {
            Console.Write("Enter the amount to deposit: ");
            deposit = int.Parse(Console.ReadLine());
            DataStore.CurrentBalance += deposit;

        }
    }

    public abstract class MonthlyExpense
    {


        public void monthlyExpense()
        {
            Console.WriteLine("Enter your monthly expenses:");
            Console.Write("Rent: ");
            int rent = int.Parse(Console.ReadLine());
            Console.Write("Groceries: ");
            int groceries = int.Parse(Console.ReadLine());
            Console.Write("Bills: ");
            int bills = int.Parse(Console.ReadLine());
            int totalExpenses = rent + groceries + bills;


            if (totalExpenses > DataStore.AvailableBalance)
            {
                Console.WriteLine("Warning: You cannot expense more than your available balance!");
                Console.WriteLine("Total monthly expense you were input: " + totalExpenses);
                Console.WriteLine("Total Available Balance: " + DataStore.AvailableBalance);
            }
            else
            {
                DataStore.MonthlyExpense += totalExpenses;
                Console.WriteLine("Total Monthly Expenses: " + totalExpenses);
            }
        }

        abstract public void dailyExpense();
    }

    public class DailyExpense : MonthlyExpense
    {
        public override void dailyExpense()
        {
            Console.WriteLine("Enter your daily expenses:");
            Console.Write("Food: ");
            int food = int.Parse(Console.ReadLine());
            Console.Write("Transport: ");
            int transport = int.Parse(Console.ReadLine());
            Console.Write("Entertainment: ");
            int entertainment = int.Parse(Console.ReadLine());
            int totalDailyExpenses = food + transport + entertainment;


            if (totalDailyExpenses > DataStore.AvailableBalance)
            {
                Console.WriteLine("Warning: You cannot expense more than your available balance!");
                Console.WriteLine("Total daily expense you were input: " + totalDailyExpenses);
                Console.WriteLine("Total Available Balance: " + DataStore.AvailableBalance);
            }
            else
            {
                DataStore.MonthlyExpense += totalDailyExpenses;
                Console.WriteLine("Total Daily Expenses: " + totalDailyExpenses);
            }
        }
    }




    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Expense Tracker!");
        Console.WriteLine("Please log in to continue.");
        Login login = new Login();
        Console.Write("Username: ");
        login.userName = Console.ReadLine();
        Console.Write("Password: ");
        login.password = Console.ReadLine();

        Transaction transaction = new Transaction();
        DailyExpense dx = new DailyExpense();

        bool isAuthenticated = false;
        while (!isAuthenticated)
        {
            if (login.Authenticate())
            {
                transaction.userName = login.userName;
                isAuthenticated = true;
                transaction.info();
                bool hasDeposited = false;

                while (true)
                {
                    Console.WriteLine("\nCurrent Balance: " + DataStore.AvailableBalance);
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Deposit Amount");
                    Console.WriteLine("2. Monthly Expense");
                    Console.WriteLine("3. Daily Expense");
                    Console.WriteLine("4. Exit");

                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            transaction.depositAmount();
                            hasDeposited = true;
                            break;

                        case "2":
                            if (!hasDeposited)
                            {
                                Console.WriteLine("Please deposit an amount before entering monthly expenses.");
                            }
                            else
                            {
                                dx.monthlyExpense();
                            }
                            break;

                        case "3":
                            if (!hasDeposited)
                            {
                                Console.WriteLine("Please deposit an amount before entering monthly expenses.");
                            }
                            else
                            {
                                dx.dailyExpense();
                            }
                            break;
                            return;

                        case "4":
                            Console.WriteLine("Thanks for using Expense Tracker.");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }


            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
                Console.Write("Username: ");
                login.userName = Console.ReadLine();
                Console.Write("Password: ");
                login.password = Console.ReadLine();
            }
        }



    }


}