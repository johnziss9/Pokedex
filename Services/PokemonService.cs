using System.Net.Http;
using System.Threading.Tasks;
using Pokedex.Models;
using Newtonsoft.Json;
using System.Linq;

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

            var data = await response.Content.ReadAsAsync<PokemonData>();

            var description = data.flavor_text_entries.FirstOrDefault(d => d.Language.name == "en").flavor_text;

            var jsonOutput = @" { 'name': '" + data.Name + "', 'description': '" + description + "', 'habitat': '" + data.Habitat.Name + "', 'isLegendary': '" + data.Is_Legendary + "' } ";

            return JsonConvert.DeserializeObject<Pokemon>(jsonOutput);
        }
    }
}