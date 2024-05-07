using SpaceShuttleLaunch.Models.Contracts;

namespace SpaceShuttleLaunch.Models.LaunchWeatherCriteria
{
    public class PrecipitationCriteria : IWeatherCriteria
    {
        public bool IsSatisfiedBy(DailyForecast forecast)
        {
            return forecast.Precipitation == 0;
        }
    }
}
