using SpaceShuttleLaunch.Repositories;

namespace SpaceShuttleLaunch.Models.Contracts
{
    public interface ISpaceport : IComparable<ISpaceport>
    {
        string LocationName { get; }
        double NorthSouthLattitude { get; }
        WeatherForecastsRepository WeatherForecasts { get; }
        DailyForecast MostConvenientDayForLaunch {  get; }

        double DistanceToEquator();
        int CompareTo(ISpaceport other);
    }
}