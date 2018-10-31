using System.Collections.Generic;
using System.Data.SqlClient;
using MenuShell.Domain;

namespace MenuShell.Services.AdministratorServices
{
    public class UserSearcher
    {
        public List<User> Search(string searchword)
        {
            var resultList = new List<User>();

            if (searchword != string.Empty)
            {
                var userList = new UserLoader().LoadUsers();

                var connection = SqlHelp.ConnectToDatabase();

                using (connection)
                {
                    connection.Open();

                    var searchUsers = new SqlCommand("SELECT Username FROM [User]" +
                                                     $"WHERE Username LIKE '%{searchword}%'", connection);

                    var readSearch = searchUsers.ExecuteReader();

                    while (readSearch.Read())
                        for (var i = 0; i < readSearch.FieldCount; i++)
                        {
                            var userMatch = userList.Find(x =>
                                readSearch != null && x.Username == readSearch[i].ToString());

                            if (userMatch != null) resultList.Add(userMatch);
                        }

                    connection.Close();
                }
            }

            return resultList;
        }
    }
}