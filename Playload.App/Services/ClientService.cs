namespace Playload.App.Services
{
    public class ClientService : BaseService
    {
        public ClientService(string baseUrl, string apiKey) : base(baseUrl, apiKey) { }

        public async Task<string> GetClientIdAsync(string id)
        {
            string endpoint = $"/rest/api/client/{id}";
            return await GetAsync(endpoint);
        }

        public async Task<string> GetAllClientsAsync()
        {
            string endpoint = "/rest/api/client";
            return await GetAsync(endpoint);
        }

        public async Task<string> GetClientAsyncByFistNameLastName(string firstName, string lastName)
        {
            string endpoint = $"/rest/api/client?filter=[{{'property':'first_name', 'value':'{firstName}'}},{{'property':'last_name', 'value':'{lastName}'}}]\"";
            return await GetAsync(endpoint);
        }

    }

}
