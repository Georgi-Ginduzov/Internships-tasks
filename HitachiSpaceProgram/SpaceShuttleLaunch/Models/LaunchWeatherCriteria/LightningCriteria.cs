using SpaceShuttleLaunch.Models.Contracts;

namespace SpaceShuttleLaunch.Models.LaunchWeatherCriteria
{
    public class LightningCriteria : IWeatherCriteria
    {
        public bool IsSatisfiedBy(IWeatherForecast forecast)
        {
            return forecast.Lightning == "No";
        }
    }
}
