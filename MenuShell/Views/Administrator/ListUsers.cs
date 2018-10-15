using System;
using MenuShell.Services;

namespace MenuShell.Views
{
    public class ListUsers : BaseView
    {
        public ListUsers() : base("All users")
        {
        }

        public override void Display()
        {
            Console.Clear();
            var loadUsers = new UserLoader();

            var users = loadUsers.LoadUsers();

            foreach (var user in users)
            {
                Console.WriteLine($"# Role: {user.Role}, Username: {user.Username}\n");
            }

            Console.WriteLine("\nPress anything to go back.");
        }
    }
}