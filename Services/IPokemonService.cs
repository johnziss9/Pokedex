using System.Threading.Tasks;

namespace Pokedex.Services
{
    public interface IPokemonService
    {
        Task<string> Get(string name);
    }
}