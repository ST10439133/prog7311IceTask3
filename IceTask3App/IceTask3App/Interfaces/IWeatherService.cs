using IceTask3App.Models;

namespace IceTask3App.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetWeatherAsync(string city);
    }
}
