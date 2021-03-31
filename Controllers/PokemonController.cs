using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PokemonController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Get(string name)
        {
            var httpClient = _httpClientFactory.CreateClient("pokeApi");

            // Hard coded the name to test if url brings the correct data
            var url = $"pikachu";

            var response = await httpClient.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}