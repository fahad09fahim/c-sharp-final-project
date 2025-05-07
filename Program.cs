using System;

public class Expense
{

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
        protected int deposit = 0;
        protected int balance = 0;
        public void info()
        {
            Console.WriteLine("Successfully Logged! Welcome, " + userName);
        }
        public void depositAmount()
        {
            Console.WriteLine("Enter the amount to deposit: ");
            deposit = int.Parse(Console.ReadLine());
            balance += deposit;
            Console.WriteLine("Your current balance is: " + balance);
        }
        public void viewBalance()
        {
            Console.WriteLine("Your current balance is: " + balance);
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

        bool isAuthenticated = false;
        while (!isAuthenticated)
        {
            if (login.Authenticate())
            {
                isAuthenticated = true;
                transaction.info();

                while (true)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Deposit Amount");
                    Console.WriteLine("2. View Balance");
                    Console.WriteLine("3. Exit");

                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            transaction.depositAmount();
                            break;

                        case "2":
                            transaction.viewBalance();
                            break;

                        case "3":
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