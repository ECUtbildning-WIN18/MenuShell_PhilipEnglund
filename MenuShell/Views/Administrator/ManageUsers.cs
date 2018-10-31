using System;

namespace MenuShell.Views
{
    public class ManageUsers : BaseView
    {
        public ManageUsers() : base("Manage users")
        {
        }

        public override void Display()
        {
            Console.Clear();
            Console.WriteLine("1. Add users.\n" +
                              "2. List users.\n" +
                              "3. Search users\n\n" +
                              "Press enter to go back.");
        }
    }
}