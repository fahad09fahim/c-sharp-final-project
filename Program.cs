/*
   ====================== Instructions:=========================
    Login credentials are: 
    Username: fahad password: test12, Username: hamza password: test34, Username: humaera password: test56
    Feature of this program:
    1. After logging in, you can deposit an amount.(without deposit you cannot enter monthly and daily expenses, #zero deposit amount not accepted).
    2. You can enter monthly expenses only once in a month.
    3. You can enter daily expenses multiple times in a month.
    4. You can view your monthly and daily expenses.
    5. You cannot view your monthly and daily expenses without depositing an amount.
    6. Negative numbers, invalid inputs are not allowed.
    7. You cannot expense more than your available balance.
    8. You can exit the program at any time.
*/
using System;

public class ExpenseTracker
{

    //To store and calculate all input data
    public class DataStore
    {
        public static double CurrentBalance = 0;
        public static double TotalExpenses = 0;
        public static double AvailableBalance
        {
            get { return CurrentBalance - TotalExpenses; }
        }

        public static double TotalMonthlyExpenses = 0;
        public static double Rent = 0;
        public static double Groceries = 0;
        public static double UtilityBills = 0;

        public static double TotalDailyExpenses = 0;
        public static double Food = 0;
        public static double Transport = 0;
        public static double Entertainment = 0;



    }

    public class Login
    {
        //Hardcoded user credentials for login
        string[,] users = {
            { "fahad", "test12" },
            { "hamza", "test34" },
            {"humaera","test56"}
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

        private double deposit = 0;
        public void info()
        {
            Console.WriteLine("Successfully Logged! Welcome, " + userName.ToUpper());
        }
        public void depositAmount()
        {
            try
            {
                Console.Write("Enter the amount to deposit: ");
                deposit = double.Parse(Console.ReadLine());
                if (deposit > 0)
                {
                    DataStore.CurrentBalance += deposit;
                }
                else if (deposit == 0)
                {
                    Console.WriteLine("You cannot deposit zero.");
                }
                else
                {
                    Console.WriteLine("Please enter positive number.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Please enter positive Number.");
            }

        }
    }

    public abstract class MonthlyExpense
    {

        public void monthlyExpense()
        {
            Console.WriteLine("Enter your monthly fixed expenses: (Note: You can only enter at once in a month.)");

            double rent = 0;
            double groceries = 0;
            double bills = 0;
            double totalExpenses = 0;

            try
            {
                //Input for monthly expenses
                Console.Write("Rent: ");
                rent = (double.Parse(Console.ReadLine()));
                if (rent > 0)
                {
                    Console.Write("Groceries: ");
                    groceries = double.Parse(Console.ReadLine());
                    if (groceries > 0)
                    {
                        Console.Write("Utility Bills: ");
                        bills = double.Parse(Console.ReadLine());
                        if (bills > 0)
                        {
                            totalExpenses += rent;
                            totalExpenses += groceries;
                            totalExpenses += bills;


                            //Total monthly  expenses calculation
                            if (totalExpenses > DataStore.AvailableBalance)
                            {
                                Console.WriteLine("Warning: You cannot expense more than your available balance!");
                                Console.WriteLine($"Total monthly expense you entered: ${totalExpenses:F2}");
                                Console.WriteLine($"Total Available Balance: ${DataStore.AvailableBalance:F2}");
                            }
                            else
                            {
                                //for storing monthly individual expenses in DataStore
                                DataStore.Rent = +rent;
                                DataStore.Groceries = +groceries;
                                DataStore.UtilityBills = +bills;
                                DataStore.TotalMonthlyExpenses = +totalExpenses;
                                //for calculating total expenses
                                DataStore.TotalExpenses += totalExpenses;
                                Console.WriteLine($"Total Monthly Expenses: ${totalExpenses:F2}");
                            }

                        }
                        else
                        {
                            totalExpenses *= 0;
                            Console.WriteLine("Invalid Input.(Possible inputs are only positive numbers.)");
                        }
                    }
                    else
                    {
                        totalExpenses *= 0;
                        Console.WriteLine("Invalid Input.(Possible inputs are only positive numbers.)");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input.(Possible inputs are only positive numbers.)");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Enter positive Number.");
            }



        }

        abstract public void dailyExpense();
    }

    public class DailyExpense : MonthlyExpense
    {
        public override void dailyExpense()
        {
            Console.WriteLine("Enter your daily expenses: ");


            double food = 0;
            double transport = 0;
            double entertainment = 0;
            double totalDailyExpenses = 0;
            try
            {
                //Input for daily expenses
                Console.Write("Food: ");
                food = double.Parse(Console.ReadLine());
                if (food >= 0)
                {
                    Console.Write("Transport: ");
                    transport = double.Parse(Console.ReadLine());
                    if (transport >= 0)
                    {

                        Console.Write("Entertainment: ");
                        entertainment = double.Parse(Console.ReadLine());
                        if (entertainment >= 0)
                        {
                            totalDailyExpenses += food;
                            totalDailyExpenses += transport;
                            totalDailyExpenses += entertainment;

                            //Total daily expenses calculation
                            if (totalDailyExpenses > DataStore.AvailableBalance)
                            {
                                Console.WriteLine("Warning: You cannot expense more than your available balance!");
                                Console.WriteLine($"Total daily expense you entered: ${totalDailyExpenses:F2}");
                                Console.WriteLine($"Total Available Balance: ${DataStore.AvailableBalance:F2}");
                            }
                            else
                            {
                                //for storing daily individual expenses in DataStore
                                DataStore.Food = +food;
                                DataStore.Transport = +transport;
                                DataStore.Entertainment = +entertainment;
                                DataStore.TotalDailyExpenses = +totalDailyExpenses;

                                //for calculating total expenses
                                DataStore.TotalExpenses += totalDailyExpenses;
                                Console.WriteLine($"Total Daily Expenses: ${totalDailyExpenses:F2}");
                            }

                        }
                        else
                        {
                            totalDailyExpenses *= 0;
                            Console.WriteLine("Invalid Input.(Possible inputs are only positive numbers.)");
                        }
                    }
                    else
                    {
                        totalDailyExpenses *= 0;
                        Console.WriteLine("Invalid Input.(Possible inputs are only positive numbers.)");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input.(Possible inputs are only positive numbers.)");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Enter positive Number.");
            }

        }
    }

    interface IExpenseTracker
    {
        void monthlyExpense();
        void dailyExpense();
    }
    public class ViewDetails : IExpenseTracker
    {
        public void monthlyExpense()
        {
            Console.WriteLine("Monthly Expense Details: ");
            Console.WriteLine("Rent: $" + (DataStore.Rent > 0 ? $"{DataStore.Rent:F2}" : 0));
            Console.WriteLine("Groceries: $" + (DataStore.Groceries > 0 ? $"{DataStore.Groceries:F2}" : 0));
            Console.WriteLine("Utility Bills: $" + (DataStore.UtilityBills > 0 ? $"{DataStore.UtilityBills:F2}" : 0));
            Console.WriteLine($"Total Monthly Expenses: ${DataStore.TotalMonthlyExpenses:F2}");
        }

        public void dailyExpense()
        {
            Console.WriteLine("Daily Expense Details:");
            Console.WriteLine("Food: $" + (DataStore.Food > 0 ? $"{DataStore.Food:F2}" : 0));
            Console.WriteLine("Transport: $" + (DataStore.Transport > 0 ? $"{DataStore.Transport:F2}" : 0));
            Console.WriteLine("Entertainment: $" + (DataStore.Entertainment > 0 ? $"{DataStore.Entertainment:F2}" : 0));
            Console.WriteLine($"Total Daily Expenses: ${DataStore.TotalDailyExpenses:F2}");
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
        ViewDetails viewDetails = new ViewDetails();

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
                    Console.WriteLine($"\nCurrent Balance: ${DataStore.AvailableBalance:F2}");
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Deposit Amount");
                    Console.WriteLine("2. Monthly Expense");
                    Console.WriteLine("3. Daily Expense");
                    Console.WriteLine("4. View Monthly Expense Details");
                    Console.WriteLine("5. View Daily Expense Details");
                    Console.WriteLine("6. Exit");

                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            transaction.depositAmount();
                            hasDeposited = (DataStore.CurrentBalance > 0) ? true : false;
                            break;

                        case "2":
                            if (!hasDeposited)
                            {
                                Console.WriteLine("Please deposit an amount before entering monthly expenses.");
                            }
                            else
                            {
                                if (DataStore.TotalMonthlyExpenses > 0 && DataStore.Rent > 0 && DataStore.Groceries > 0 && DataStore.UtilityBills > 0)
                                {
                                    Console.WriteLine("You have already entered monthly expenses. Please choose option 4 to view them.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("You can only enter monthly expenses once.");
                                    dx.monthlyExpense();
                                }

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
                            if (!hasDeposited)
                            {
                                Console.WriteLine("No Data Found. This is your first time using this app. Try option 1.");
                            }
                            else
                            {
                                viewDetails.monthlyExpense();
                            }
                            break;
                            return;
                        case "5":
                            if (!hasDeposited)
                            {
                                Console.WriteLine("No Data Found. This is your first time using this app. Try option 1.");
                            }
                            else
                            {
                                viewDetails.dailyExpense();
                            }
                            break;
                            return;
                        case "6":
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

