using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MenuShell.Domain;

namespace MenuShell.Services
{
    public class UserLoader
    {
        public List<User> LoadUsers()
        {
            var users = new List<User>();

            var connection = SqlHelp.ConnectToDatabase();

            var userTable = new SqlCommand("WITH UserData AS " +
                                                          "(SELECT ROW_NUMBER() OVER(ORDER BY Username) as Row#," +
                                                          " * FROM [User])" +
                                                          $" SELECT * FROM UserData", connection);

            using (connection)
            {
                connection.Open();

                var readUserTable = userTable.ExecuteReader();
                var userTableRows = new List<string>();
                while (readUserTable.Read())
                {
                    userTableRows.Add(readUserTable[1].ToString());
                }
                    
                readUserTable.Close();

                if (userTableRows.Count != 0)
                    for (var i = 1; i <= userTableRows.Count; i++)
                    {
                        var userData = new SqlCommand("WITH UserData AS " +
                                                      "(SELECT ROW_NUMBER() OVER(ORDER BY Username) as Row#," +
                                                      " Username, Password, Role FROM [User])" +
                                                      $" SELECT * FROM UserData WHERE Row# = {i};", connection);

                        var readUserData = userData.ExecuteReader();

                        while (readUserData.Read())
                        {
                            var username = readUserData[1].ToString();
                            var password = readUserData[2].ToString();
                            var role = readUserData[3].ToString();

                            var access = (Role) Enum.Parse(typeof(Role), role);

                            users.Add(new User(username, password, access));
                        }
                        
                        readUserData.Close();
                    }

                connection.Close();
            }

            return users;
        }
    }
}