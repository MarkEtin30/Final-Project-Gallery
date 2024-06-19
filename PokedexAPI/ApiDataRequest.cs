using System.IO;
using System.Net;
using System.Text.Json;
using System.Windows;

namespace PokedexAPI
{
    public class ApiDataRequest
    {
        public string Url1 { get; set; }

        private int currentPosition = 0;

        public ApiDataRequest()
        {
            Url1 = "https://pokeapi.co/api/v2/pokemon?limit=10&offset=";
        }

        public PokemonListClass1 GetPokemonListFromAPI()
        {
            HttpWebRequest httpWebRequest1 = (HttpWebRequest)WebRequest.Create(Url1 + currentPosition);
            httpWebRequest1.Method = "GET";
            httpWebRequest1.ContentType = "application/json";
            httpWebRequest1.Accept = "application/json";


            try
            {
                using (WebResponse response1 = httpWebRequest1.GetResponse())
                {
                    using (Stream stream1 = response1.GetResponseStream())
                    {
                        if (stream1 == null)
                        {
                            return null;
                        }

                        using (StreamReader reader1 = new StreamReader(stream1))
                        {
                            string responseText1 = reader1.ReadToEnd();
                            // JsonConvert.DererializeObject<PokemonListClass1>(responseText1);
                            PokemonListClass1 pokemonList1 = JsonSerializer.Deserialize<PokemonListClass1>(responseText1);

                            return pokemonList1;


                        }

                    }
                }

            }
            catch (Exception exception1)
            {
                MessageBox.Show("There was the problem: " + exception1.Message);
                throw;
            }





        }
    }
}
