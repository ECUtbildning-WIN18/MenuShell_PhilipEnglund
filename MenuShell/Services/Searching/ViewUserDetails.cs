using System;
using MenuShell.Domain;

namespace MenuShell.Services.Searching
{
    public class ViewUserDetails
    {
        public void Display(User user)
        {
            Console.Clear();

            Console.WriteLine($"{user.Username}\n" +
                              $"{user.Role.ToString()}\n" +
                              "\n If you wish to delete this user, press D.\n" +
                              "To go back, press ESC.");
        }
    }
}