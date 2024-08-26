using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace Playload.App.Services
{
    public class AuthService : BaseService
    {
        public AuthService(string baseUrl, string apiKey) : base(baseUrl, apiKey) { }

        public async Task<string> AuthenticateAsync(string login, string password)
        {
            const string appName = "playbook";
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(login), "login");
            content.Add(new StringContent(password), "password");
            content.Add(new StringContent(appName), "app_name");

            return await PostAsync("/token_auth.php", content);
        }
    }
}
