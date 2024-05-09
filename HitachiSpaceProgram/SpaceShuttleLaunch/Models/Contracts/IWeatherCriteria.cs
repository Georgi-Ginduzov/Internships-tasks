namespace SpaceShuttleLaunch.Models.Contracts
{
    public interface IWeatherCriteria
    {
        public bool IsSatisfiedBy(IWeatherForecast forecast);
    }
}
