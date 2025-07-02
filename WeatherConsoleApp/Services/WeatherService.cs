using System.Text.Json;
using WeatherConsoleApp.Models;

namespace WeatherConsoleApp.Services
{
    class WeatherService
    {
        static public WeatherRoot? GetWeather(string apiKey, string city)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
                var response = client.GetAsync($"weather?q={city}&appid={apiKey}&units=metric").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var weatherData = JsonSerializer.Deserialize<WeatherRoot>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return weatherData;
                }
                else
                {
                    throw new Exception($"Error fetching weather data: {response.ReasonPhrase}");
                }
            }
        }
    }
}
