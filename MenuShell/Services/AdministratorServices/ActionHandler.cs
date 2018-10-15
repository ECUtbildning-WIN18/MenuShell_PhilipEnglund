using System;
using System.Runtime.InteropServices;
using MenuShell.Domain;
using MenuShell.Views;

namespace MenuShell.Services.AdministratorServices
{
    public class ActionHandler
    {
        public bool ContinueOrExit()
        {
            while (true)
            {
                var input = Console.ReadKey(true);
                
                if (input.Key == ConsoleKey.D1)
                {
                    break;
                }

                if (input.Key == ConsoleKey.E)
                {
                    var wishToExit = StandardMessages.WishToExit();

                    if (wishToExit)
                    {
                        Environment.Exit(0);
                    }
                }
            }

            return true;
        }

        public Selection GetSelection()
        {
            var input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.D1)
            {
                return Selection.One;
            }

            if (input.Key == ConsoleKey.D2)
            {
                return Selection.Two;
            }

            if (input.Key == ConsoleKey.D3)
            {
                return Selection.Three;
            }

            return Selection.GoBack;
        }

        public User SelectUser()
        {
            var loadUsers = new UserLoader();

            var users = loadUsers.LoadUsers();
            while (true)
            {
                var input = Int32.TryParse(Console.ReadLine(), out int number);

                if (input && number <= users.Count)
                {
                    return users[number];
                }
                Console.WriteLine("Try again, number too high.");
            }
        }
    }
}