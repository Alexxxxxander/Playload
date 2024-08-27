using Newtonsoft.Json;
using System.Text;

namespace Playload.App.Services
{
    public class PetService : BaseService
    {
        public PetService(string baseUrl, string apiKey) : base(baseUrl, apiKey) { }

        public async Task<string> GetPetsByOwnerIdAsync(string ownerId)
        {
            string endpoint = $"/rest/api/pet/?filter=[{{'property':'owner_id', 'value':'{ownerId}'}},{{'property':'status', 'value':'deleted', 'operator':'!='}}]";
            return await GetAsync(endpoint);
        }

        public async Task<string> GetPetByIdAsync(string petId)
        {
            string endpoint = $"/rest/api/pet/{petId}";
            return await GetAsync(endpoint);
        }

        public async Task<string> AddPetAsync(string ownerId, string breedId, string typeId, string alias, string sex, string birthday)
        {
            var petData = new
            {
                owner_id = ownerId,
                breed_id = breedId,
                type_id = typeId,
                alias = alias,
                sex = sex,
                birthday = birthday,
                date_register = DateTime.Now.ToString()
            };

            var json = JsonConvert.SerializeObject(petData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await PostAsync("/rest/api/pet", content);
        }

        public async Task<string> EditPetAsync(string petId, string ownerId, string breedId, string typeId, string alias, string sex, string birthday)
        {
            var petData = new
            {
                owner_id = ownerId,
                breed_id = breedId,
                type_id = typeId,
                alias = alias,
                sex = sex,
                birthday = birthday
            };

            var json = JsonConvert.SerializeObject(petData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            return await PutAsync($"/rest/api/pet/{petId}", content);
        }

        public async Task<string> DeletePetAsync(string petId)
        {
            return await DeleteAsync($"/rest/api/pet/{petId}");
        }


    }

}
