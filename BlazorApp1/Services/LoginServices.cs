using System.Xml.Linq;
using BlazorApp1.Models;
using Model.User;

namespace BlazorApp1.Services
{
    public class LoginServices
    {
        public User AuthenticateUser(string path, string email, string password)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(path);
                var userXML = xmlDoc.Descendants("user")
                    .FirstOrDefault(u =>
                        (string)u.Element("email") == email &&
                        (string)u.Element("password") == password);

                if (userXML != null)
                {
                    int id = int.Parse(userXML.Element("id")?.Value);
                    string userEmail = userXML.Element("email")?.Value;
                    string userPassword = userXML.Element("password")?.Value;

                    return new User(id, userEmail, userPassword);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null; // if AuthenticateUser fail traja3 null
        }

        public void RegisterUser(string path, User user)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(path);
                var usersXML = xmlDoc.Element("users");

                XElement newUser = new XElement("user",
                    new XElement("id", user.Id),
                    new XElement("email", user.Email),
                    new XElement("password", user.Password));

                usersXML?.Add(newUser);
                xmlDoc.Save(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
