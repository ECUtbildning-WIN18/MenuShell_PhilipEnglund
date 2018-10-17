using System;
using System.Threading;
using MenuShell.Domain;
using MenuShell.Views;

namespace MenuShell.Services.AdministratorServices
{
    public class SearchUsers
    {
        public bool RunSearch()
        {
            while (true)
            {
                Console.Clear();
                RunView.SearchUsers();
                Console.SetCursorPosition(30, 0);

                var users = new UserLoader().LoadUsers();

                string searchWord = null;

                while (true)
                {
                    var searchInput = Console.ReadKey();


                    if (searchInput.Key == ConsoleKey.Escape)
                        return false;

                    if (searchInput.Key == ConsoleKey.Enter)
                        break;

                    foreach (var letter in searchInput.KeyChar.ToString()) searchWord += letter;
                }

                var result = users.FindAll(x => x.Username.ToLower().Contains(searchWord));

                if (result.Count != 0)
                    while (true)
                    {
                        new ListUsers().Display(result);
                        var userToDelete = new ActionHandler().SelectUserInList(result);

                        if (userToDelete != null)
                        {
                            StandardMessages.DisplayUserInfo(userToDelete);
                            var input = Console.ReadKey(true);
                            if (input.Key == ConsoleKey.D)
                            {
                                new DeleteUser().Delete(userToDelete);
                                StandardMessages.SuccessfullyDeletedUser(userToDelete);
                                return false;
                            }

                            return false;
                        }

                        StandardMessages.TryAgain();
                        break;
                    }

                Console.Clear();
                Console.WriteLine("User not found. Try again!");
                Thread.Sleep(1500);
            }
        }
    }
}