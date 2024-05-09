using SpaceShuttleLaunch.Models.Contracts;

namespace SpaceShuttleLaunch.Models.LaunchWeatherCriteria
{
    public class CloudsCriteria : IWeatherCriteria
    {
        public bool IsSatisfiedBy(IWeatherForecast forecast)
        {
            string clouds = forecast.Clouds.ToLower();
            return !clouds.Contains("cumulus") && !clouds.Contains("nimbus");
        }
    }
}
