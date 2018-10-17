using MenuShell.Views;

namespace MenuShell.Domain
{
    public static class RunView
    {
        public static void Login()
        {
            var loginView = new LoginView();

            loginView.Display();
        }

        public static void Administrator()
        {
            var view = new AdministratorView();

            view.Display();
        }

        public static void ManageUsers()
        {
            var manageUsers = new ManageUsers();

            manageUsers.Display();
        }

        public static void AddUsers()
        {
            var addUserView = new AddUsers();

            addUserView.Display();
        }

        public static void SearchUsers()
        {
            var searchUsersView = new UserSearch();

            searchUsersView.Display();
        }
    }
}