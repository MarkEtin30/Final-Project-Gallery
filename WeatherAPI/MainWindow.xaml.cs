// Including necessary namespaces for the application
using System.Windows; // Provides classes for creating Windows-based applications with rich user interfaces.
using Newtonsoft.Json; // Library for JSON serialization and deserialization.
using RestSharp; // Library for making REST API calls.

namespace WeatherAPI
{
    // MainWindow class inherits from Window class to create a WPF application window.
    public partial class MainWindow : Window
    {
        // API key for accessing the OpenWeatherMap API.
        private const string apiKey = "82ad9e97c5e06b4f25f4ac7935132eaa";
        // Base URL for the OpenWeatherMap API.
        private const string baseUrl = "http://api.openweathermap.org/data/2.5/forecast";

        // Constructor for MainWindow. Initializes the window components.
        public MainWindow()
        {
            InitializeComponent(); // Method that initializes the UI components.
        }

        // Event handler for the GetWeatherButton click event.
        private async void GetWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the city name entered in the CityTextBox.
            var city = CityTextBox.Text;

            // Check if the city name is not empty.
            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Please enter a city name."); // Show a message box if city name is empty.
                return; // Exit the method if no city name is entered.
            }

            // Create a new RestClient instance with the base URL.
            var client = new RestClient(baseUrl);
            // Create a new RestRequest for a GET request.
            var request = new RestRequest("", Method.Get);

            // Add query parameters to the request.
            request.AddParameter("q", city); // Add city name parameter.
            request.AddParameter("appid", apiKey); // Add API key parameter.
            request.AddParameter("units", "metric"); // Add units parameter to get the temperature in Celsius.

            try
            {
                // Execute the request asynchronously and await the response.
                var response = await client.ExecuteAsync(request);

                // Check if the response is successful.
                if (response.IsSuccessful)
                {
                    // Deserialize the JSON response to WeatherData object.
                    var weatherData = JsonConvert.DeserializeObject<WeatherData>(response.Content);
                    // Display the weather data in the UI.
                    DisplayWeather(weatherData);
                }
                else
                {
                    MessageBox.Show("Error retrieving weather data."); // Show error message if response is not successful.
                }
            }
            catch (Exception ex)
            {
                // Catch any exceptions that occur during the API call and show an error message.
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Method to display the weather data in the WeatherListBox.
        private void DisplayWeather(WeatherData weatherData)
        {
            WeatherListBox.Items.Clear(); // Clear any existing items in the list box.

            // Loop through each weather forecast in the weather data.
            foreach (var forecast in weatherData.List)
            {
                // Add a formatted string to the list box for each forecast.
                WeatherListBox.Items.Add($"{forecast.DtTxt}: {forecast.Main.Temp}°C, {forecast.Weather[0].Description}");
            }
        }
    }

    // Class to represent the weather data structure received from the API.
    public class WeatherData
    {
        // List of weather forecasts.
        [JsonProperty("list")]
        public List<WeatherForecast> List { get; set; }
    }

    // Class to represent a single weather forecast.
    public class WeatherForecast
    {
        // Date and time of the forecast.
        [JsonProperty("dt_txt")]
        public string DtTxt { get; set; }

        // Main data of the forecast, including temperature.
        [JsonProperty("main")]
        public MainData Main { get; set; }

        // List of weather conditions.
        [JsonProperty("weather")]
        public List<WeatherInfo> Weather { get; set; }
    }

    // Class to represent the main data of a weather forecast.
    public class MainData
    {
        // Temperature in Celsius.
        [JsonProperty("temp")]
        public float Temp { get; set; }
    }

    // Class to represent weather information such as description.
    public class WeatherInfo
    {
        // Description of the weather condition.
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
