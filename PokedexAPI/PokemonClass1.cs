using System.Text.Json.Serialization;

namespace PokedexAPI
{
    public class PokemonClass1
    {


        [JsonPropertyName("name")]
        public string NameOfPokemon { get; set; }


        [JsonPropertyName("types")]
        public List<PokemonType> listOfPokemonType = new List<PokemonType>();



        [JsonPropertyName("url")]
        public Uri UrlOfPicture { get; set; }



        // This field of String is infact strong the image as strings!! 
        public string StringOfImageUrlSprites { get; set; }



        public string PokemonType { get; set; }



        public List<PokemonType> PokemonTypes { get; set; } // Changed from string to List<PokemonType>
        public string PokemonType1 { get; internal set; }
        public string PokemonType2 { get; internal set; }


        public int Height { get; set; }
        public int Weight { get; set; }
        public List<string> Abilities { get; set; }
        public List<StatDetail> Stats { get; set; }


        public double HeightInMeters => Height / 10.0;
        public double WeightInKilograms => Weight / 10.0;
    }

    public class StatDetail
    {
        public string Name { get; set; }
        public int BaseStat { get; set; }
    }



}
