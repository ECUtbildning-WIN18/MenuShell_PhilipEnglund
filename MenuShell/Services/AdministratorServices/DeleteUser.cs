using System;
using System.Collections.Generic;
using System.Xml.Linq;
using MenuShell.Domain;

namespace MenuShell.Services.AdministratorServices
{
    public class DeleteUser
    {
        public void Delete(User user)
        {  
            var doc = XDocument.Load("Users.xml");

            var root = doc.Root;

            foreach (var element in root.Elements())
            {
                if (element.Element("username").Value == user.Username)
                {
                    element.Element("username").Parent.Remove();
                }
            }

            doc.Save("Users.xml");
        }
    }
}