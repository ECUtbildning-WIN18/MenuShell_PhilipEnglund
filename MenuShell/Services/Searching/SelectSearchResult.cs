using System;
using System.Collections.Generic;
using MenuShell.Domain;

namespace MenuShell.Views
{
    public class SelectSearchResult
    {
        public User SelectUser(List<User> resultList)
        {
            var selection = Console.ReadKey(true);

            if (selection.Key == ConsoleKey.Escape)
                return null;

            var number = Convert.ToInt16(selection.KeyChar.ToString());

            return resultList[number - 1];
        }
    }
}