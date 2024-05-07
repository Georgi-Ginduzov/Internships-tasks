using SpaceShuttleLaunch.Models.Contracts;

namespace SpaceShuttleLaunch.Models.LaunchWeatherCriteria
{
    public class TemperatureCriteria : IWeatherCriteria
    {
        public bool IsSatisfiedBy(DailyForecast forecast)
        {
            var temperature = forecast.Temperature;
            return temperature >= 1 && temperature <= 32;

        }
    }
}
