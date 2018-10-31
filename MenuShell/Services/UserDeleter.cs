using System.Data.SqlClient;
using MenuShell.Domain;

namespace MenuShell.Services.AdministratorServices
{
    public class UserDeleter
    {
        public void Delete(User user)
        {
            var connection = SqlHelp.ConnectToDatabase();

            connection.Open();

            var deleteUserCommand = new SqlCommand("DELETE FROM [User]" +
                                                   $"WHERE Username LIKE '{user.Username}'",connection);

            deleteUserCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}