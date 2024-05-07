using SpaceShuttleLaunch.Models.Contracts;

namespace SpaceShuttleLaunch.Models
{
    public class DailyForecast : IComparable, IWeatherForecast
    {
        public DailyForecast()
        {

        }

        public int Date { get; set; }

        public float Temperature { get; set; }

        public float WindSpeed { get; set; }

        public int Humidity { get; set; }

        public int Precipitation { get; set; }

        public string Lightning { get; set; }

        public string Clouds { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is DailyForecast other)
            {
                double thisWindSpeed = WindSpeed;
                double otherWindSpeed = other.WindSpeed;
                double thisHumidity = Humidity;
                double otherHumidity = other.Humidity;

                int windSpeedComparison = thisWindSpeed.CompareTo(otherWindSpeed);
                if (windSpeedComparison == 0)
                {
                    // If WindSpeed is equal, compare Humidity
                    return thisHumidity.CompareTo(otherHumidity);
                }
                else
                {
                    return windSpeedComparison;
                }
            }
            else
            {
                throw new ArgumentException("Object is not a DailyForecast");
            }
        }
    }
}
