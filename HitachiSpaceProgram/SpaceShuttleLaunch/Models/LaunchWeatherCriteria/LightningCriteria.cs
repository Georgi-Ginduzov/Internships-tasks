using SpaceShuttleLaunch.Models.Contracts;

namespace SpaceShuttleLaunch.Models.LaunchWeatherCriteria
{
    public class LightningCriteria : IWeatherCriteria
    {
        public bool IsSatisfiedBy(DailyForecast forecast)
        {
            return forecast.Lightning == "No";
        }
    }
}
