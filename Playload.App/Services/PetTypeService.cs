using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playload.App.Services
{
    public class PetTypeService : BaseService
    {
        public PetTypeService(string baseUrl, string apiKey) : base(baseUrl, apiKey) { }

        public async Task<string> GetPetTypesAsync()
        {
            string endpoint = "/rest/api/petType";
            return await GetAsync(endpoint);
        }
    }

}
