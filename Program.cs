using System;

public class Expense
{

    public class Login
    {
        //Hardcoded user credentials for login
        string[,] users = {
            { "fahim", "user123" },
            { "hamza", "pass123" },
            {"huma","word123"}
        };
        private string userName;
        private string password;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool Authenticate()
        {
            for (int i = 0; i < users.GetLength(0); i++)
            {
                if (users[i, 0] == userName && users[i, 1] == password)
                    return true;
            }
            return false;
        }

    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Expense Tracker!");
        Console.WriteLine("Please log in to continue.");
        Login login = new Login();
        Console.Write("Username: ");
        login.UserName = Console.ReadLine();
        Console.Write("Password: ");
        login.Password = Console.ReadLine();

        bool isAuthenticated = false;
        while (!isAuthenticated)
        {
            if (login.Authenticate())
            {
                isAuthenticated = true;
                Console.WriteLine("Successfully Logged! Welcome, " + login.UserName);
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
                Console.Write("Username: ");
                login.UserName = Console.ReadLine();
                Console.Write("Password: ");
                login.Password = Console.ReadLine();
            }
        }

    }


}