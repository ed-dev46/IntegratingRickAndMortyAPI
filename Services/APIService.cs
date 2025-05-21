using System.Text.Json;
using IntegrationRickAndMortyAPI.Models;

namespace IntegrationRickAndMortyAPI.Services
{
    public class APIService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://rickandmortyapi.com/api/";
        public APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<Character>> GetAllCharactersAsync(int page)
        {
            var response = await _httpClient.GetAsync($"character?page={page}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var characterResponse = JsonSerializer.Deserialize<CharacterResponse>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return characterResponse.Results ?? new List<Character>();
            }
            else
            {
                throw new Exception($"Error fetching characters: {response.ReasonPhrase}");
            }
        }

        public async Task<string> GetCharacterByNameAsync(string name)
        {
            var response = await _httpClient.GetAsync($"character?name={name}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Error fetching character: {response.ReasonPhrase}");
            }
        }

    }
}
