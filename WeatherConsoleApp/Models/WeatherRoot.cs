namespace WeatherConsoleApp.Models
{
    class WeatherRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MainWeather Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Wind Wind { get; set; }
        public Coordinates Coord { get; set; }
    }
    class MainWeather
    {
        public double Temp { get; set; }
        public double Humidity { get; set; }
        public double SeaLevel { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }

    }
    class Weather
    {
        public string Description { get; set; }
    }
    class Wind
    {
        public double Speed { get; set; }
        public double Deg { get; set; }
        public double Gust { get; set; }
    }
    class Coordinates
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
}