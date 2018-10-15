using System;

namespace MenuShell.Views
{
    public class LoginView : BaseView
    {
        public LoginView() : base("Login")
        {
        }

        public override void Display()
        {
            Console.WriteLine("#################################\n" +
                              "############# Login  ############\n" +
                              "#                               #\n" +
                              "# Username:                     #\n" +
                              "#                               #\n" +
                              "# Password:                     #\n" +
                              "#                               #\n" +
                              "#                               #\n" +
                              "#################################");
        }
    }
}