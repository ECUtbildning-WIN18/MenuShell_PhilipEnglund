using System.Data.SqlClient;

namespace MenuShell.Services
{
    public class SqlHelp
    {
        public static SqlConnection ConnectToDatabase()
        {
            var connectionString = "Data Source=(local);Initial Catalog=MenuShell; Integrated Security=true";

            var connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}