using System;

namespace MenuShell.Views
{
    public class AdministratorView : BaseView
    {
        public AdministratorView() : base("Administrator")
        {
        }


        public override void Display()
        {
            Console.Clear();
            Console.WriteLine("1. Manage users.\n\n" +
                              "(E)xit.");
        }
    }
}