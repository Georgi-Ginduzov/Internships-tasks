using SpaceShuttleLaunch.Models.Contracts;
using SpaceShuttleLaunch.Repositories.Contracts;
using SpaceShuttleLaunch.Utilities.Messages;

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
            get
            {
                if (!models.Any())
                {
                    throw new InvalidOperationException(ExceptionMessages.NoForecastsAvailable);
                }
                return models.First();
            }
        }

        public void Add(IWeatherForecast model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), ExceptionMessages.ModelCannotBeNull);
            }
            models.Add(model);
        }
    }
}
