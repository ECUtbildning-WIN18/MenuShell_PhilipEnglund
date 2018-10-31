using System;

namespace MenuShell.Views
{
    public class UserSearch : BaseView
    {
        public UserSearch() : base("Search Users")
        {
        }

        public override void Display()
        {
            Console.Clear();
            Console.WriteLine("Search for users by username: \n\n");
        }
    }
}