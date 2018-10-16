using System;
using System.Collections.Generic;
using System.Xml.Linq;
using MenuShell.Domain;

namespace MenuShell.Services
{
    public class UserLoader
    {
        public List<User> LoadUsers()
        {
            var users = new List<User>();

            var doc = XDocument.Load("Users.xml");

            var root = doc.Root;

            foreach (var element in root.Elements())
            {
                var username = element.Element("username").Value;
                var role = element.Element("role").Value;
                var password = element.Element("password").Value;

                var access = (Role) Enum.Parse(typeof(Role), role);

                var user = new User(username, password, access);

                users.Add(user);
            }

            return users;
        }
    }
}