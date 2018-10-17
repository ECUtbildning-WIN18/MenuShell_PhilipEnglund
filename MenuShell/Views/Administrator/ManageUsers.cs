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
            Console.WriteLine("1. Add user.\n" +
                              "2. Search users.\n\n" +
                              "Press enter to go back.");
        }
    }
}