using System.Text.Json.Serialization;

namespace PokedexAPI
{
    public class PokemonListClass1

    {

        [JsonPropertyName("results")]

        public List<PokemonClass1> PokemonList1 { get; set; }




        [JsonPropertyName("count")]

        public long Count { get; set; }



        [JsonPropertyName("next")]

        public Uri Next { get; set; }




        [JsonPropertyName("previous")]

        public object Previous { get; set; }




    }
}
