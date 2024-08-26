using Newtonsoft.Json.Linq;
using Playload.App.Services;

namespace Playload.App
{
    public partial class FormSettings : Form
    {
        string apiKey = "dd2d278ae9f98cb809b48b0ca7cd84d8";
        FileService fileService = new FileService();
        public FormSettings()
        {
            InitializeComponent();
            LoadDataFromXml();
        }

        public async void buttonConnect_Click(object sender, EventArgs e)
        {           
            const string appName = "playbook";
            string domain = textBoxDomain.Text;
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            AuthService authService = new AuthService(domain, apiKey);
            var jsonResponse = JObject.Parse(await authService.AuthenticateAsync(login, password));
            string token = jsonResponse["data"]["token"].ToString();

            fileService.LoadDataToXml(domain, login, password, token);

            MessageBox.Show($"Токен и настройки успешно сохранены");
            this.Close();
        }
        private void LoadDataFromXml()
        {
            textBoxDomain.Text = fileService.GetAllDataFromXml().domain;
            textBoxLogin.Text = fileService.GetAllDataFromXml().login;
            textBoxPassword.Text = fileService.GetAllDataFromXml().password;
        }

    }
}
