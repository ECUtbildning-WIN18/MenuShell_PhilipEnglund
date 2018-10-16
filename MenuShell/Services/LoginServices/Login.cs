using System;
using MenuShell.Domain;
using MenuShell.Interfaces;

namespace MenuShell.Services.LoginServices
{
    public class Login : IAuthenticationService
    {
        public User CollectUserData()
        {
            Console.SetCursorPosition(12, 3);
            var username = Console.ReadLine();

            Console.SetCursorPosition(12, 5);
            string password = null;

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                    break;

                foreach (var letter in key.KeyChar.ToString())
                {
                    Console.Write("*");
                    password += letter;
                }
            }

            var user = new User(username, password);

            return user;
        }

        public User Validate(User user)
        {
            var loadUsers = new UserLoader();

            var users = loadUsers.LoadUsers();

            var loggedUser = users.Find(x => x.Username == user.Username && x.Password == user.Password);

            return loggedUser;
        }
    }
}