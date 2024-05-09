using SpaceShuttleLaunch.Models.Contracts;

namespace SpaceShuttleLaunch.Models.LaunchWeatherCriteria
{
    public class WeatherCriteria
    {
        private readonly List<IWeatherCriteria> criteria;

        public WeatherCriteria(List<IWeatherCriteria> criteria)
        {
            this.criteria = criteria;
        }

        public bool IsWeatherSuitable(IWeatherForecast forecast)
        {
            return criteria.All(criterion => criterion.IsSatisfiedBy(forecast));
        }
    }
}
