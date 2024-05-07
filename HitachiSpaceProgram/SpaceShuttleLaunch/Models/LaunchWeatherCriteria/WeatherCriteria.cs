using SpaceShuttleLaunch.Models.Contracts;

namespace SpaceShuttleLaunch.Models.LaunchWeatherCriteria
{
    public class WeatherCriteria
    {
        private readonly List<IWeatherCriteria> _criteria;

        public WeatherCriteria(List<IWeatherCriteria> criteria)
        {
            _criteria = criteria;
        }

        public bool IsWeatherSuitable(DailyForecast forecast)
        {
            return _criteria.All(criterion => criterion.IsSatisfiedBy(forecast));
        }
    }
}
