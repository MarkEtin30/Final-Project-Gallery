public class WeatherResponse
{
    public CurrentWeather CurrentWeather { get; set; }
}

public class CurrentWeather
{
    public float Temperature { get; set; }
    public string WeatherCode { get; set; }
}