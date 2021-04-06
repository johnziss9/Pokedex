using System.Net.Http;
using System.Threading.Tasks;
using Pokedex.Models;

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

            // var pokemonId = 25;// response.Content.ReadAsAsync<Pokemon>().Id;

            // var newResponse = await _httpClient.GetAsync(pokemonId.ToString());

            // var x = JsonConvert.DeserializeObject<Pokemon>(response.Content.ToString());

            // var y = JsonConvert.SerializeObject(x);

            return await response.Content.ReadAsAsync<Pokemon>();
        }
    }
}