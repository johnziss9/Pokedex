using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.Services;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("{name}")]
        public async Task<Pokemon> Get(string name)
        {
            return await _pokemonService.Get(name);
        }

        [HttpGet("translated/{name}")]
        public async Task<Pokemon> GetTranslated(string name)
        {
            return await _pokemonService.GetTranslated(name);
        }
    }
}