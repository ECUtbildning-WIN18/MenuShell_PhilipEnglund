using System.Data.SqlClient;
using MenuShell.Domain;

namespace MenuShell.Services.AdministratorServices
{
    public class UserSaver
    {
        public void SaveUser(User user)
        {
            var sqlConnection = SqlHelp.ConnectToDatabase();

            using (sqlConnection)
            {
                sqlConnection.Open();

                var addUser = new SqlCommand(
                    "INSERT INTO [User] " +
                    $"VALUES ('{user.Username}'," +
                    $" '{user.Password}', " +
                    $"'{user.Role.ToString()}')",
                    sqlConnection);

                addUser.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}