using System;
using System.Collections.Generic;
using MenuShell.Domain;

namespace MenuShell.Views
{
    public class ListUsers
    {
        public void Display(List<User> users)
        {
            Console.Clear();

            var count = 1;

            foreach (var user in users)
            {
                Console.WriteLine($"{count} Role: {user.Role}, Username: {user.Username}\n");
                count++;
            }


            Console.WriteLine("\nPress number to view user details.");
        }
    }
}