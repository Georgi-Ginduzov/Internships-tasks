using SpaceShuttleLaunch.Models;
using SpaceShuttleLaunch.Models.Contracts;
using SpaceShuttleLaunch.Repositories.Contracts;

namespace SpaceShuttleLaunch.Repositories
{
    public class WeatherForecastsRepository : IRepository<IWeatherForecast>
    {
        private SortedSet<IWeatherForecast> models;

        public WeatherForecastsRepository()
        {
            models = new SortedSet<IWeatherForecast>();
        }

        public IReadOnlyCollection<IWeatherForecast> Models => models;
        public IWeatherForecast MostSuitableForecast 
        { 
            get => models.First();
        }

        public void Add(IWeatherForecast model)
        {
            models.Add(model);
        }
    }
}
