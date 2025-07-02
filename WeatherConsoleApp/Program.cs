using WeatherConsoleApp.Models;
using WeatherConsoleApp.Services;

string apiKey = "3a605f068da62859e080c491f677fee5";
string city = "London";

while (true)
{

    Console.Write("Input Your city:");
    city = Console.ReadLine() ?? city;
    
    WeatherRoot showingWeatherData = WeatherService.GetWeather(apiKey, city);


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