using Newtonsoft.Json.Linq;
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
            int offset = 0;
            int limit = 0;

            string endpoint = $"/rest/api/breed?filter=[{{'property':'pet_type_id', 'value':'{petTypeId}'}}]&limit={limit}&offset={offset}";
            string response = await GetAsync(endpoint);
            var allBreeds = JObject.Parse(response);

            limit = 100;
            int totalCount = int.Parse(allBreeds["data"]["totalCount"].ToString());
            
            do
            {
                endpoint = $"/rest/api/breed?filter=[{{'property':'pet_type_id', 'value':'{petTypeId}'}}]&limit={limit}&offset={offset}";
                response = await GetAsync(endpoint);
                var responseJson = JObject.Parse(response);
                var breeds = responseJson["data"]["breed"] as JArray;

                if (breeds != null && breeds.Count > 0)
                {
                    foreach (var breed in breeds)
                    {
                        (allBreeds["data"]["breed"] as JArray).Add(breed);
                    }
                }
                // Увеличиваем offset для следующей страницы
                offset += limit;
            }
            while (offset < totalCount);
            return allBreeds.ToString();
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
