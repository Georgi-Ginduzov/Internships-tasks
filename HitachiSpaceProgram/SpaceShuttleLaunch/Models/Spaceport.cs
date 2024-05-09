using SpaceShuttleLaunch.Models.Contracts;
using SpaceShuttleLaunch.Repositories;

namespace SpaceShuttleLaunch.Models
{
    public class Spaceport : ISpaceport, IComparable<ISpaceport>
    {
        private string locationName;
        private double northSouthLattitude;
        private WeatherForecastsRepository weatherForecasts;

        public Spaceport(string locationName, WeatherForecastsRepository weatherForecasts)
        {
            WeatherForecasts = weatherForecasts;
            LocationName = locationName;
        }

        public string LocationName
        {
            get => locationName;
            private set
            {
                string[] locationNameInput = value.Split('.');
                string fileName = locationNameInput[0].ToLower();

                switch (fileName)
                {
                    case "kourou":
                        NorthSouthLattitude = 5.15970;
                        break;
                    case "capecanaveral":
                        NorthSouthLattitude = 28.4740;
                        break;
                    case "tanegashima":
                        NorthSouthLattitude = 30.6096;
                        break;
                    case "mahia":
                        NorthSouthLattitude = 39.0806;
                        break;
                    case "kodiak":
                        NorthSouthLattitude = 57.7900;
                        break;
                    default:
                        break;
                }

                locationName = fileName;
            }
        }
        public double NorthSouthLattitude { get => northSouthLattitude; private set => northSouthLattitude = value; } // api request could be made to get the lattitude of the location
        public WeatherForecastsRepository WeatherForecasts 
        { 
            get => weatherForecasts; 
            private set 
            { 
                weatherForecasts = value; 
            } 
        }
        public DailyForecast MostConvenientDayForLaunch 
        { 
            get => weatherForecasts.Models.First() as DailyForecast;
        }

        public int CompareTo(ISpaceport? other)
        {
            int distanceComparison = DistanceToEquator().CompareTo(other.DistanceToEquator());
            if (distanceComparison != 0)
            {
                return distanceComparison;
            }

            return MostConvenientDayForLaunch.CompareTo(other.MostConvenientDayForLaunch);
        }

        public double DistanceToEquator()
        {
            return Math.Abs(this.NorthSouthLattitude) * 111;
        }


    }
}
