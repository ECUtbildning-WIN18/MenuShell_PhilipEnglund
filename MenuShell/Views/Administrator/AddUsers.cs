using System;

namespace MenuShell.Views
{
    public class AddUsers : BaseView
    {
        public AddUsers() : base("Add users")
        {
        }

        public override void Display()
        {
            Console.Clear();
            Console.WriteLine("Username: \n" +
                              "Password: \n" +
                              "Role: \n\n" +
                              "Press enter to save. Press backspace to start over.");
        }
    }
}