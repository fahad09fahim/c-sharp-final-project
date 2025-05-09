using System;

public class ExpenseTracker
{

    //To store and calculate all input data
    public class DataStore
    {
        public static int CurrentBalance = 0;
        public static int TotalExpenses = 0;
        public static int AvailableBalance
        {
            get { return CurrentBalance - TotalExpenses; }
        }

        public static int TotalMonthlyExpenses = 0;
        public static int Rent = 0;
        public static int Groceries = 0;
        public static int UtilityBills = 0;

        public static int TotalDailyExpenses = 0;
        public static int Food = 0;
        public static int Transport = 0;
        public static int Entertainment = 0;



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

        private int deposit = 0;
        public void info()
        {
            Console.WriteLine("Successfully Logged! Welcome, " + userName.ToUpper());
        }
        public void depositAmount()
        {
            try
            {
                Console.Write("Enter the amount to deposit: ");
                deposit = int.Parse(Console.ReadLine());
                if (deposit > 0)
                {
                    DataStore.CurrentBalance += deposit;
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


            int rent = 0;
            int groceries = 0;
            int bills = 0;
            int totalExpenses = 0;

            try
            {

                Console.Write("Rent: ");
                rent = (int.Parse(Console.ReadLine()));
                if (rent > 0)
                {
                    Console.Write("Groceries: ");
                    groceries = int.Parse(Console.ReadLine());
                    if (groceries > 0)
                    {
                        Console.Write("Utility Bills: ");
                        bills = int.Parse(Console.ReadLine());
                        if (bills > 0)
                        {
                            totalExpenses += rent;
                            totalExpenses += groceries;
                            totalExpenses += bills;


                            //Total monthly  expenses calculation
                            if (totalExpenses > DataStore.AvailableBalance)
                            {
                                Console.WriteLine("Warning: You cannot expense more than your available balance!");
                                Console.WriteLine("Total monthly expense you entered: " + totalExpenses);
                                Console.WriteLine("Total Available Balance: " + DataStore.AvailableBalance);
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
                                Console.WriteLine("Total Monthly Expenses: " + totalExpenses);
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
            Console.WriteLine("Enter your daily expenses:)");


            int food = 0;
            int transport = 0;
            int entertainment = 0;
            int totalDailyExpenses = 0;
            try
            {
                Console.Write("Food: ");
                food = int.Parse(Console.ReadLine());
                if (food > 0)
                {

                    Console.Write("Transport: ");
                    transport = int.Parse(Console.ReadLine());
                    if (transport > 0)
                    {

                        Console.Write("Entertainment: ");
                        entertainment = int.Parse(Console.ReadLine());
                        if (entertainment > 0)
                        {
                            totalDailyExpenses += food;
                            totalDailyExpenses += transport;
                            totalDailyExpenses += entertainment;

                            //Total daily expenses calculation
                            if (totalDailyExpenses > DataStore.AvailableBalance)
                            {
                                Console.WriteLine("Warning: You cannot expense more than your available balance!");
                                Console.WriteLine("Total daily expense you entered: " + totalDailyExpenses);
                                Console.WriteLine("Total Available Balance: " + DataStore.AvailableBalance);
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
                                Console.WriteLine("Total Daily Expenses: " + totalDailyExpenses);
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
            Console.WriteLine("Rent: " + (DataStore.Rent > 0 ? DataStore.Rent : 0));
            Console.WriteLine("Groceries: " + (DataStore.Groceries > 0 ? DataStore.Groceries : 0));
            Console.WriteLine("Utility Bills: " + (DataStore.UtilityBills > 0 ? DataStore.UtilityBills : 0));
            Console.WriteLine("Total Monthly Expenses: " + DataStore.TotalMonthlyExpenses);
        }

        public void dailyExpense()
        {
            Console.WriteLine("Daily Expense Details:");
            Console.WriteLine("Food: " + (DataStore.Food > 0 ? DataStore.Food : 0));
            Console.WriteLine("Transport: " + (DataStore.Transport > 0 ? DataStore.Transport : 0));
            Console.WriteLine("Entertainment: " + (DataStore.Entertainment > 0 ? DataStore.Entertainment : 0));
            Console.WriteLine("Total Daily Expenses: " + DataStore.TotalDailyExpenses);
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
                    Console.WriteLine("\nCurrent Balance: " + DataStore.AvailableBalance);
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
                            hasDeposited = true;
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

