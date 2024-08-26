using System.Xml.Linq;

namespace Playload.App.Services
{
    internal class FileService
    {
        const string appName = "playbook";
        const string xmlFilePath = "data.xml";
        public FileService() { }

        public (string domain, string login, string password, string token) GetAllDataFromXml()
        {
            try
            {
                var xmlDocument = XDocument.Load(xmlFilePath);
                var settings = xmlDocument.Element("ApiSettings");
                string domain = settings.Element("Domain").Value;
                string login = settings.Element("Login").Value;
                string password = settings.Element("Password").Value;
                string token = settings.Element("Domain").Value;

                return (domain, login, password, token);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Файл с настройками не найден");
                return ("", "", "", "");
            }
        }

        public void LoadDataToXml(string domain, string login, string password, string token)
        {
            var xmlDocument = new XDocument(
                new XElement("ApiSettings",
                    new XElement("Token", token),
                    new XElement("Domain", domain),
                    new XElement("Login", login),
                    new XElement("Password", password))
            );
            xmlDocument.Save(xmlFilePath);
        }
    }
}
