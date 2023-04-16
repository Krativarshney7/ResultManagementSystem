using BLL.Service;
using Common;

namespace Assignment;

public class LoginUser
{
    LoginService loginService;

    public LoginUser()
    {
        loginService = new();
    }

    public void ViewPage()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Result Management System");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Quit");
            Console.Write("Enter choice: ");

            string inputVal = Console.ReadLine();
            if (inputVal.Length == 0)
                Console.WriteLine("You never skip the entry");
            else if (int.TryParse(inputVal, out int choiceInt))
            {
                switch (choiceInt)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        exit = true;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter valid choice!");
                        break;
                }
            }
            else
                Console.WriteLine("Only Digits are allowed");
            Console.ReadKey();
        }
    }

    public void Login()
    {
        User user = new();
        do
        {
            bool isValidUsername = false;
            do
            {
                Console.Write("Enter your Username: ");
                user.Username = Console.ReadLine();
                if (string.IsNullOrEmpty(user.Username))
                {
                    Console.WriteLine("Username cannot be empty.");
                }
                else
                {
                    if (loginService.IsUserExists(user.Username))
                        isValidUsername = true;
                    else
                        Console.WriteLine("No such user exists!");
                }
            } while (!isValidUsername);

            do
            {
                Console.Write("Enter your Password: ");
                user.Password = Console.ReadLine();
                if (string.IsNullOrEmpty(user.Password))
                {
                    Console.WriteLine("Password cannot be empty.");
                }
            } while (string.IsNullOrEmpty(user.Password));

            if (loginService.UserLogin(user.Username, user.Password))
            {
                LoginMenu loginMenu = new();
                loginMenu.ShowMenu();
                break;
            }
            else
                Console.WriteLine("Please enter correct username and password");
        }
        while (!loginService.UserLogin(user.Username, user.Password));
    }
}
