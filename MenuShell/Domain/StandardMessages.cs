using System;
using System.Threading;
using MenuShell.Domain;

namespace MenuShell
{
    public static class StandardMessages
    {
        public static void Welcome()
        {
            Console.WriteLine("#######################################\n" +
                              "####                               ####\n" +
                              "####                               ####\n" +
                              "####          Welcome!             ####\n" +
                              "####                               ####\n" +
                              "####                               ####\n" +
                              "#######################################");

            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void TryAgain()
        {
            Console.Clear();
            Console.WriteLine("Ooops, something doesn't add up, try again.");
            Thread.Sleep(2500);

            Console.Clear();
        }

        public static void Success()
        {
            Console.Clear();
            Console.WriteLine("Action succeeded!");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void LoggedInAs(Role role)
        {
            Console.WriteLine($"Logged in as {role}");
            Thread.Sleep(1800);
            Console.Clear();
        }

        public static bool WishToExit()
        {
            Console.WriteLine("Do you really want to exit? y/n");

            var input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.Y)
            {
                return true;
            }

            return false;
        }
    }
}