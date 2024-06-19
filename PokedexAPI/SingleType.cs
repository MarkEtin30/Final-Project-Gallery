using System.Text.Json.Serialization;

namespace PokedexAPI
{
    public class SingleType
    {


        [JsonPropertyName("name")]
        public string nameOfType { get; set; }


    }
}