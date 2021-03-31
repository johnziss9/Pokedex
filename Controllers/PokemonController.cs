using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private static HttpClient _httpClient;

        public PokemonController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> Get(string name)
        {
            // Hard coded the name to test if url brings the correct data
            var url = $"https://pokeapi.co/api/v2/pokemon/pikachu";
            
            var response = await _httpClient.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}