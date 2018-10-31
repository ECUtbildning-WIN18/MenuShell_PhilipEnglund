using System;
using System.Collections.Generic;
using MenuShell.Domain;
using MenuShell.Services.AdministratorServices;

namespace MenuShell.Services
{
    public class SearchUser
    {
        public List<User> Search()
        {
            List<User> searchResultList = null;

            var searching = true;
            while (searching)
            {
                Console.SetCursorPosition(30, 0);

                string searchword = null;

                while (true)
                {
                    var inputKey = Console.ReadKey();
                        
                    if (inputKey.Key == ConsoleKey.Enter)
                        break;

                    foreach (var letter in inputKey.KeyChar.ToString()) searchword += letter;
                }

                if (searchword != null)
                {
                    searchResultList = new UserSearcher().Search(searchword);
                    if (searchResultList.Count != 0 && searchResultList != null)
                    {
                        break;
                    }
                    
                    StandardMessages.NoMatch();
                    break;
                }
            }

            return searchResultList;
        }
    }
}