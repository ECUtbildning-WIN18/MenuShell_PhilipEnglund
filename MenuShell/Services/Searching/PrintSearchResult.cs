using System;
using System.Collections.Generic;
using MenuShell.Domain;

namespace MenuShell.Views
{
    public class PrintSearchResult
    {
        public void Display(List<User> resultList)
        {
            Console.Clear();

            var count = 0;

            foreach (var result in resultList)
            {
                count++;
                Console.WriteLine("--------------------------------------------------------------\n" +
                                  $"{count}. {result.Username}          {result.Role.ToString()}\n" +
                                  "--------------------------------------------------------------\n");
            }

            Console.WriteLine("\nPress numbers to view user details. Press ESC to go back.");
        }
    }
}