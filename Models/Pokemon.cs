using System.Collections.Generic;

namespace Pokedex.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FlavorTextEntry> flavor_text_entries { get; set; }
        public Habitat Habitat { get; set; }
        public bool IsLegendary { get; set; }
    }
}