using Largo_EvaluacionP3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largo_EvaluacionP3.Services_SL
{
    public class NarutoAPIService_SL
    {
        private readonly HttpClient _httpClient;

        public NarutoAPIService_SL()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://narutodb.xyz/") };
        }

        public async Task<List<CharacterModel_SL>> GetCharactersAsync()
        {
            var response = await _httpClient.GetAsync("api/v1/characters");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CharacterModel_SL>>(content);
            }
            return null;
        }
    }
}
