using SpaceShuttleLaunch.Models.Contracts;

namespace SpaceShuttleLaunch.Models.LaunchWeatherCriteria
{
    public class HumidityCriteria : IWeatherCriteria
    {
        public bool IsSatisfiedBy(DailyForecast forecast)
        {
            var humidity = forecast.Humidity;
            return humidity < 55;
        }
    }
}
