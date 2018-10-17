using System;
using System.Collections.Generic;
using MenuShell.Domain;

namespace MenuShell.Services.AdministratorServices
{
    public class ActionHandler
    {
        public Selection GetSelection()
        {
            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    return Selection.One;
                case ConsoleKey.D2:
                    return Selection.Two;
                case ConsoleKey.D3:
                    return Selection.Three;
                case ConsoleKey.E:
                    return Selection.Exit;
                default:
                    return Selection.GoBack;
            }
        }

        public User SelectUserInList(List<User> users)
        {
            while (true)
            {
                int.TryParse(Console.ReadLine(), out var number);

                if (number <= users.Count)
                {
                    number--;
                    return users[number];
                }

                Console.WriteLine("Try again, number too high.");
            }
        }
    }
}