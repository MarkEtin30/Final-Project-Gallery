using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PokedexAPI
{
    public partial class MainWindow : Window
    {
        private HttpClient client1 = new HttpClient();
        private List<PokemonClass1> allPokemonList = new List<PokemonClass1>(); // Store all Pokémon data

        public MainWindow()
        {
            InitializeComponent();
            client1.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            DataContext = this;
        }

        private async void Button_Click_Load_Pokemons_From_API(object sender, RoutedEventArgs e)
        {
            LoadingProgressBar.Visibility = Visibility.Visible;
            LoadPokemonsButton.IsEnabled = false;

            try
            {
                PokemonListClass1 pokemonListFromAPI1 = await GetPokemonListFromAPIAsync();
                allPokemonList.Clear(); // Clear previous data

                foreach (PokemonClass1 pokemon in pokemonListFromAPI1.PokemonList1)
                {
                    PokemonDetail pokemonDetail = await GetPokemonDetailFromAPIAsync(pokemon.UrlOfPicture);
                    string pokemonType1 = pokemonDetail.Types.FirstOrDefault()?.Type.Name ?? "unknown";
                    string pokemonType2 = pokemonDetail.Types.Skip(1).FirstOrDefault()?.Type.Name ?? "";

                    allPokemonList.Add(new PokemonClass1
                    {
                        NameOfPokemon = char.ToUpper(pokemon.NameOfPokemon[0]) + pokemon.NameOfPokemon.Substring(1),
                        StringOfImageUrlSprites = pokemonDetail.Sprites.Front_Default,
                        PokemonType1 = pokemonType1,
                        PokemonType2 = pokemonType2,
                        Height = pokemonDetail.Height,
                        Weight = pokemonDetail.Weight,
                        Abilities = pokemonDetail.Abilities.Select(a => a.AbilityInfo.Name).ToList(),
                        Stats = pokemonDetail.Stats.Select(s => new StatDetail { Name = s.StatInfo.Name, BaseStat = s.BaseStat }).ToList()
                    });
                }

                PokemonListBox.ItemsSource = allPokemonList;
            }
            finally
            {
                LoadingProgressBar.Visibility = Visibility.Hidden;
                LoadPokemonsButton.IsEnabled = true;
                SearchButton.Visibility = Visibility.Visible;
            }
        }

        private async Task<PokemonListClass1> GetPokemonListFromAPIAsync()
        {
            HttpResponseMessage response1 = await client1.GetAsync("pokemon?offset=0&limit=50");
            response1.EnsureSuccessStatusCode();
            return await response1.Content.ReadFromJsonAsync<PokemonListClass1>();
        }

        private async Task<PokemonDetail> GetPokemonDetailFromAPIAsync(Uri url)
        {
            HttpResponseMessage response = await client1.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PokemonDetail>();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredList = allPokemonList.Where(p => p.NameOfPokemon.ToLower().Contains(searchText)).ToList();
            PokemonListBox.ItemsSource = filteredList;
            PokemonListBox.SelectedItem = null;

        }

        private void UsersListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {



            if (PokemonListBox.SelectedItem is PokemonClass1 selectedPokemon)

            {

                NameOfPokemonTextBlock.Text = $"Name: {selectedPokemon.NameOfPokemon}";
                ImageOfPokemon.Source = LoadImageFromUrl(selectedPokemon.StringOfImageUrlSprites);

                if (selectedPokemon.PokemonType2 != "")
                {
                    TypeOfPokemonTextBlock.Text = $"Type: {selectedPokemon.PokemonType1}, {selectedPokemon.PokemonType2}";
                }
                else
                {
                    TypeOfPokemonTextBlock.Text = $"Type: {selectedPokemon.PokemonType1}";
                }

                HeightTextBlock.Text = $"Height: {selectedPokemon.HeightInMeters:F1} m";
                WeightTextBlock.Text = $"Weight: {selectedPokemon.WeightInKilograms:F1} kg";
                AbilitiesTextBlock.Text = "Abilities: " + string.Join(", ", selectedPokemon.Abilities);
                StatsTextBlock.Text = "Stats: " + string.Join(", ", selectedPokemon.Stats.Select(s => $"{s.Name}: {s.BaseStat}"));
            }
        }

        private BitmapImage LoadImageFromUrl(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                byte[] imageData = webClient.DownloadData(url);

                BitmapImage bitmap = new BitmapImage();
                using (var stream = new System.IO.MemoryStream(imageData))
                {
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                }
                return bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
                return null;
            }
        }
    }

    public class PokemonDetail
    {
        [JsonPropertyName("sprites")]
        public Sprites Sprites { get; set; }

        [JsonPropertyName("types")]
        public List<PokemonType> Types { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("abilities")]
        public List<Ability> Abilities { get; set; }

        [JsonPropertyName("stats")]
        public List<Stat> Stats { get; set; }

    }



    public class Sprites
    {
        [JsonPropertyName("front_default")]
        public string Front_Default { get; set; }
    }

    public class PokemonType
    {
        [JsonPropertyName("type")]
        public TypeInfo Type { get; set; }

        [JsonPropertyName("slot")]
        public int Slot { get; set; }
    }

    public class TypeInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
    public class Ability
    {
        [JsonPropertyName("ability")]
        public TypeInfo AbilityInfo { get; set; }
    }

    public class Stat
    {
        [JsonPropertyName("base_stat")]
        public int BaseStat { get; set; }

        [JsonPropertyName("stat")]
        public TypeInfo StatInfo { get; set; }
    }


    public class PokemonTypeToBrushConverter : IValueConverter
    {
        private static Dictionary<string, Brush> typeToBrush = new Dictionary<string, Brush>
        {
            { "normal", Brushes.Gray },
            { "fighting", Brushes.DarkRed },
            { "flying", Brushes.LightSkyBlue },
            { "poison", Brushes.Purple },
            { "ground", Brushes.Brown },
            { "rock", Brushes.SandyBrown },
            { "bug", Brushes.LightGreen },
            { "ghost", Brushes.Purple },
            { "steel", Brushes.Silver },
            { "fire", Brushes.Red },
            { "water", Brushes.CadetBlue },
            { "grass", Brushes.Green },
            { "electric", Brushes.Yellow },
            { "psychic", Brushes.DeepPink },
            { "ice", Brushes.LightBlue },
            { "dragon", Brushes.DarkSlateBlue },
            { "dark", Brushes.DarkSlateGray },
            { "fairy", Brushes.LightPink },
            { "unknown", Brushes.Gray },
            { "shadow", Brushes.Black }
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string type && typeToBrush.ContainsKey(type))
            {
                return typeToBrush[type];
            }

            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public void DisplaySelectedPokemon()
        {

        }
    }
}
