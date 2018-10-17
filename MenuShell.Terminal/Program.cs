using System;
using System.Threading;
using MenuShell.Domain;
using MenuShell.Services.AdministratorServices;
using MenuShell.Services.LoginServices;

namespace MenuShell.Terminal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StandardMessages.Welcome();

            var actionHandler = new ActionHandler();

            var tryLogin = new Login();

            var menu = true;
            while (menu)
            {
                User loggedUser = null;

                RunView.Login();

                var user = tryLogin.CollectUserData();

                loggedUser = tryLogin.Validate(user);

                if (loggedUser != null)
                {
                    StandardMessages.Success();
                    StandardMessages.LoggedInAs(loggedUser.Role);

                    var employeeMenu = true;
                    while (employeeMenu)
                    {
                        if (loggedUser.Role == Role.Administrator)
                        {
                            RunView.Administrator();

                            var select = actionHandler.GetSelection();

                            if (select == Selection.One)
                            {
                                var userManagerMenu = true;
                                while (userManagerMenu)
                                {
                                    RunView.ManageUsers();
                                    var selection = actionHandler.GetSelection();

                                    if (selection == Selection.One)
                                    {
                                        RunView.AddUsers();

                                        new CreateUser().Create();
                                    }

                                    if (selection == Selection.Two)
                                    {
                                        var searchUser = new SearchUsers();

                                        var search = true;
                                        do
                                        {
                                            search = searchUser.RunSearch();
                                        } while (search);
                                    }

                                    if (selection == Selection.GoBack) break;
                                }
                            }

                            if (select == Selection.Two)
                            {
                                var logout = StandardMessages.WishToLogout();
                                if (logout)
                                    break;
                            }

                            if (select == Selection.Exit)
                            {
                                var wishToExit = StandardMessages.WishToExit();
                                if (wishToExit) Environment.Exit(0);

                                Console.Clear();
                                break;
                            }
                        }

                        if (loggedUser.Role == Role.Receptionist)
                        {
                            Console.WriteLine(
                                "This feature will be added in the next release. \n" +
                                "We knew you would test it though..");
                            Thread.Sleep(2000);
                            break;
                        }
                    }
                }

                if (loggedUser == null)
                    StandardMessages.TryAgain();
            }
        }
    }
}