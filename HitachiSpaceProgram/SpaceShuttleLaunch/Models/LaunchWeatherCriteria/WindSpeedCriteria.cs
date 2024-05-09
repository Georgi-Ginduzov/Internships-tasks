using SpaceShuttleLaunch.Models.Contracts;

namespace SpaceShuttleLaunch.Models.LaunchWeatherCriteria
{
    public class WindSpeedCriteria : IWeatherCriteria
    {
        public bool IsSatisfiedBy(IWeatherForecast forecast)
        {
            var windSpeed = forecast.WindSpeed;
            return windSpeed <= 11;
        }
    }
}
