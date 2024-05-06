namespace SpaceShuttleLaunch.Models
{
    public class Spaceport
    {
        public SortedSet<DailyForecast> Forecasts { get; set; }

        public Spaceport()
        {
            Forecasts = new SortedSet<DailyForecast>();
        }

        public void AddForecast(DailyForecast forecast)
        {
            Forecasts.Add(forecast);
        }
    }
}
