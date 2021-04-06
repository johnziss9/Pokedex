using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pokedex.Models
{
    public class PokemonData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FlavorTextEntry> flavor_text_entries { get; set; }
        public Habitat Habitat { get; set; }
        public bool Is_Legendary { get; set; }
    }
}