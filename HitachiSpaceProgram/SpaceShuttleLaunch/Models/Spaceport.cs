using SpaceShuttleLaunch.Models.Contracts;
using SpaceShuttleLaunch.Repositories;
using SpaceShuttleLaunch.Utilities.Messages;

namespace SpaceShuttleLaunch.Models
{
    public class Spaceport : ISpaceport, IComparable<ISpaceport>
    {
        private readonly int maxTries = 5;

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
            get
            {
                if(locationName == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.CannotBeNull, "Location name");
                }

                return locationName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    for (int i = 0; i < maxTries; i++)
                    {
                        Console.WriteLine(ExceptionMessages.CannotBeNull, "Location name");
                        value = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            break;
                        }
                    }
                    throw new ArgumentException(ExceptionMessages.MaxAttemptsReached);
                }

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
        public double NorthSouthLattitude // api request could be made to get the lattitude of the location
        {
            get => northSouthLattitude;
            
            private set => northSouthLattitude = value; 
        } 
        public WeatherForecastsRepository WeatherForecasts 
        { 
            get
            {
                if (weatherForecasts == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.ModelCannotBeNull, "Weather forecast");
                }

                return weatherForecasts;
            } 
            private set 
            {
                if (value != null)
                {
                    weatherForecasts = value; 
                }

                throw new ArgumentNullException(ExceptionMessages.ModelCannotBeNull, "Weather forecast");
            } 
        }
        public DailyForecast MostConvenientDayForLaunch
        {
            get
            {
                
                if(WeatherForecasts.Models.Any())
                {
                    throw new InvalidOperationException(ExceptionMessages.NoForecastsAvailable);
                }

                return weatherForecasts.Models.First() as DailyForecast;
            }
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
