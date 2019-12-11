using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonExplorerWPF
{
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Pokemons
    {
        [JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; }
    }
    public class Sprites
    {
        [JsonPropertyName("front_default")]
        public string Front_default { get; set; }
        [JsonPropertyName("back_default")]
        public string Back_default { get; set; }
    }
    public class PokemonDetail
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("weight")]
        public double Weight { get; set; }
        [JsonPropertyName("abilities")]
        public IEnumerable<Abilities> Abilities { get; set; }

        [JsonPropertyName("sprites")]
        public Sprites Sprites { get; set; }
    }
    public class Abilities
    {
        [JsonPropertyName("ability")]
        public Ability Ability { get; set; }
    }

    public class Ability
    {
        [JsonPropertyName("name")]
        public string Name
        {
            get; set;
        }
    }
}
