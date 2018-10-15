using System.Xml.Linq;
using MenuShell.Domain;

namespace MenuShell.Services.AdministratorServices
{
    public class UserSave
    {
        public void SaveUser(User user)
        {
            var userlist = XDocument.Load("Users.xml");

            var root = userlist.Root;

            var userInfo = new XElement("user",
                new XElement("username", user.Username),
                new XElement("role", user.Role.ToString()),
                new XElement("password", user.Password));

            root.Add(userInfo);

            userlist.Save("Users.xml");
        }
    }
}