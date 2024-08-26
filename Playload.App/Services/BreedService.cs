using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playload.App.Services
{
    internal class BreedService : BaseService
    {
        public BreedService(string baseUrl, string apiKey) : base(baseUrl, apiKey) { }

        public async Task<string> GetAllBreedsAsync()
        {
            string endpoint = "/rest/api/breed?limit=400";
            return await GetAsync(endpoint);
        }

        public async Task<string> GetAllBreedsFilteredByPetType(string petTypeId)
        {
            string endpoint = $"/rest/api/breed?filter=[{{'property':'pet_type_id', 'value':'{petTypeId}'}}]&limit=400";
            return await GetAsync(endpoint);
        }

        public async Task<string> GetBreedById(string breedId)
        {
            string endpoint = $"/rest/api/breed/{breedId}";
            return await GetAsync(endpoint);
        }

        public async Task<string> GetBreedIdByTitle(string title)
        {
            string endpoint = $"/rest/api/breed?filter=[{{'property':'title', 'value':'{title}'}}]";
            return await GetAsync(endpoint);
        }
    }
}
