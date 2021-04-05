using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Pokedex.Models;
using Newtonsoft.Json;
using System.IO;

namespace Pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pokemon> Get(string name)
        {
            string pokemonName = $"{name}";
            var response = await _httpClient.GetAsync(pokemonName);

            return await response.Content.ReadAsAsync<Pokemon>();
        }
    }
}