using System.Net.Http;
using System.Threading.Tasks;
using Pokedex.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

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

            // Deserialising the data using the PokemonData model in order for them to match.
            var data = await response.Content.ReadAsAsync<PokemonData>();

            // Picking up the first description that's written in English.
            var description = data.flavor_text_entries.FirstOrDefault(d => d.Language.name == "en").flavor_text;

            // Building the json that will be used in the response and then deserialising it using the Pokemon model.
            var jsonOutput = @" { 'name': '" + data.Name + "', 'description': '" + description + "', 'habitat': '" + data.Habitat.Name + "', 'isLegendary': '" + data.Is_Legendary + "' } ";

            return JsonConvert.DeserializeObject<Pokemon>(jsonOutput);
        }

        public async Task<Pokemon> GetTranslated(string name)
        {
            string pokemonName = $"{name}";
            var response = await _httpClient.GetAsync(pokemonName);

            // Deserialising the data using the PokemonData model in order for them to match.
            var data = await response.Content.ReadAsAsync<PokemonData>();

            // Picking up the first description that's written in English.
            var description = data.flavor_text_entries.FirstOrDefault(d => d.Language.name == "en").flavor_text;

            // This is the body that will be sent in HttpPost and below I serialise it.
            var body = @" { 'text': '" + description + "' } ";
            var serialisedBody = JsonConvert.SerializeObject(body);
            var parameters = new StringContent(serialisedBody, Encoding.UTF8, "application/json");

            // Specifying the Url and sending the request depending on the Habitat
            if (data.Habitat.Name == "cave")
            {
                var url = "	https://api.funtranslations.com/translate/yoda.json";
                using var client = new HttpClient();

                var translatedResponse = await client.PostAsync(url, parameters);

                var jsonOutput = @" { 'name': '" + data.Name + "', 'description': '" + translatedResponse + "', 'habitat': '" + data.Habitat.Name + "', 'isLegendary': '" + data.Is_Legendary + "' } ";

                return JsonConvert.DeserializeObject<Pokemon>(jsonOutput);
            }
            else
            {
                var url = "https://api.funtranslations.com/translate/shakespeare.json";
                using var client = new HttpClient();

                var translatedResponse = await client.PostAsync(url, parameters);

                var jsonOutput = @" { 'name': '" + data.Name + "', 'description': '" + translatedResponse + "', 'habitat': '" + data.Habitat.Name + "', 'isLegendary': '" + data.Is_Legendary + "' } ";

                return JsonConvert.DeserializeObject<Pokemon>(jsonOutput);
            }
        }
    }
}