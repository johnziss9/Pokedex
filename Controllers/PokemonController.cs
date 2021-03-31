using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        public async Task<string> Get(string name)
        {
            // Hard coded the name to test if url brings the correct data
            var url = $"https://pokeapi.co/api/v2/pokemon/pikachu";
            
            // Create instance of HttpClient in order to call the PokeAPI
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}