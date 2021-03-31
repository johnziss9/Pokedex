using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Get(string name)
        {
            string UrlName = $"{name}";
            var response = await _httpClient.GetAsync(UrlName);

            return await response.Content.ReadAsStringAsync();
        }
    }
}