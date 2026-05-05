using IceTask3App.Interfaces;
using IceTask3App.Models;
using System.Text.Json;

namespace IceTask3App.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "455f55d504592ff68e88538f8093b0e8";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherModel> GetWeatherAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";

            var response = await _httpClient.GetStringAsync(url);

            using JsonDocument doc = JsonDocument.Parse(response);

            var root = doc.RootElement;

            return new WeatherModel
            {
                City = city,
                Temperature = root.GetProperty("main").GetProperty("temp").GetDouble(),
                Description = root.GetProperty("weather")[0].GetProperty("description").GetString()
            };
        }
    }
}
