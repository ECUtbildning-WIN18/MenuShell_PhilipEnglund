using System;
using System.Threading;
using MenuShell.Domain;

namespace MenuShell.Services.AdministratorServices
{
    public class CreateUser
    {
        public void Create()
        {
            while (true)
            {
                Console.SetCursorPosition(10, 0);
                var username = Console.ReadLine();

                Console.SetCursorPosition(10, 1);
                var password = Console.ReadLine();

                Console.SetCursorPosition(7, 2);
                var role = Console.ReadLine();

                var isRoleValid = CheckRole.Check(role);

                if (isRoleValid)
                {
                    var access = (Role) Enum.Parse(typeof(Role), role);

                    var user = new User(username, password, access);

                    var userNotExist = UserExist.DoesAlreadyExist(user);

                    if (userNotExist)
                    {
                        var saveUser = new UserSave();

                        saveUser.SaveUser(user);
                        StandardMessages.Success();
                        break;
                    }
                }

                else
                {
                    Console.WriteLine("You can only choose 'Administrator' or 'Receptionist' as role,\n" +
                                      "or the user already exists. Try again.");
                    Thread.Sleep(2500);
                }
            }
        }
    }

    public class CheckRole
    {
        public static bool Check(string role)
        {
            if (role == "Administrator" || role == "Receptionist") return true;
            return false;
        }
    }

    public class UserExist
    {
        public static bool DoesAlreadyExist(User user)
        {
            var loadUsers = new UserLoader();

            var users = loadUsers.LoadUsers();

            if (!users.Exists(x => x.Username == user.Username && x.Password == user.Password)) return true;

            return false;
        }
    }
}