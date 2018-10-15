using System;
using System.Diagnostics.PerformanceData;
using MenuShell.Services;

namespace MenuShell.Views
{
    public class DeleteUsers : BaseView
    {
        public DeleteUsers() : base("Delete users")
        {
        }

        public override void Display()
        {
            Console.Clear();
            var loadUsers = new UserLoader();

            var users = loadUsers.LoadUsers();
            int counter = 0;
            
            foreach (var user in users)
            {
                Console.WriteLine($"{counter}. Role: {user.Role}, Username: {user.Username}\n");
                counter++;
            }
        }
    }
}