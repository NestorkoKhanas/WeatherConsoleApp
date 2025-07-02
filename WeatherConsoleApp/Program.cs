using System.ComponentModel;
using System.Text.Json;
using WeatherConsoleApp.Models;

string apiKey = "3a605f068da62859e080c491f677fee5";
string city = "London";

while (true)
{

    Console.Write("Input Your city:");
    city = Console.ReadLine() ?? city;
    
    WeatherRoot showingWeatherData = GetWeather(apiKey, city);


    if (showingWeatherData != null)
    {
        Console.WriteLine($"City: {showingWeatherData.Name}");
        Console.WriteLine($"Temperature: {showingWeatherData.Main.Temp}°C");
        Console.WriteLine($"Humidity: {showingWeatherData.Main.Humidity}%");
        Console.WriteLine($"Weather: {showingWeatherData.Weather[0].Description}");
        Console.WriteLine($"Wind Speed: {showingWeatherData.Wind.Speed} m/s");
    }
    else
    {
        Console.WriteLine("Failed to retrieve weather data.");

    }
}


WeatherRoot? GetWeather(string apiKey, string city)
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