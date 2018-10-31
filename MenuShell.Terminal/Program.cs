using System;
using MenuShell.Domain;
using MenuShell.Services;
using MenuShell.Services.AdministratorServices;
using MenuShell.Services.LoginServices;
using MenuShell.Services.Searching;
using MenuShell.Views;

namespace MenuShell.Terminal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StandardMessages.Welcome();

            var loginView = new LoginView();

            var login = new Login();

            User loggedUser = null;

            while (true)
            {
                loginView.Display();

                var user = login.CollectUserData();

                loggedUser = login.Validate(user);

                if (loggedUser != null)
                {
                    StandardMessages.Success();
                    StandardMessages.LoggedInAs(loggedUser.Role);
                    break;
                }

                StandardMessages.TryAgain();
            }

            var administratorView = new AdministratorView();

            while (true)
            {
                if (loggedUser.Role == Role.Administrator)
                {
                    administratorView.Display();

                    var actionHandler = new ActionHandler();

                    var select = actionHandler.GetSelection();

                    if (select == Selection.One)
                    {
                        var manageUsers = new ManageUsers();

                        manageUsers.Display();

                        while (true)
                        {
                            var selection = actionHandler.GetSelection();

                            if (selection == Selection.One)
                            {
                                var addUserView = new AddUsers();

                                addUserView.Display();

                                var userCreator = new CreateUser();

                                userCreator.Create();
                                break;
                            }

                            if (selection == Selection.Two)
                            {
                                var listUsers = new ListUsers();

                                listUsers.Display();

                                var input = Console.ReadKey(true);
                                break;
                            }

                            if (selection == Selection.Three)
                            {
                                var searching = true;
                                while (searching)
                                {
                                    new UserSearch().Display();

                                    var searchResult = new SearchUser().Search();

                                    if (searchResult != null && searchResult.Count != 0)
                                    {
                                        new PrintSearchResult().Display(searchResult);

                                        var viewUser = new SelectSearchResult().SelectUser(searchResult);

                                        if (viewUser != null)
                                        {
                                            new ViewUserDetails().Display(viewUser);

                                            var DeleteOrExit = actionHandler.GetSelection();

                                            if (DeleteOrExit == Selection.Delete)
                                                new UserDeleter().Delete(viewUser);
                                                StandardMessages.Success();
                                        }
                                    }
                                    
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        var wishToExit = StandardMessages.WishToExit();

                        if (wishToExit) Environment.Exit(0);
                    }
                }

                if (loggedUser.Role == Role.Receptionist)
                {
                    Console.WriteLine(
                        "This feature will be added in the next release. We knew you would test it though..");
                    break;
                }
            }
        }
    }
}