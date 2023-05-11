using AutoMapper;
using Toolbox.Domain;
using Toolbox.Dto.Response;

namespace Toolbox.Service
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        private readonly IMapper _mapper;
        public WeatherForecastService(IMapper mapper) {
            _mapper = mapper;
        }

        public IEnumerable<WeatherForecastResponse> GetAll()
        {
            var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return _mapper.Map<IEnumerable<WeatherForecastResponse>>(weatherForecasts);
        }
    }
}