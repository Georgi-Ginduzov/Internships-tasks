using SpaceShuttleLaunch.Models.Contracts;
using System.Text;

namespace SpaceShuttleLaunch.Models
{
    public class Spaceport : ISpaceport, IComparable<ISpaceport>
    {
        private string locationName;
        private double lattitude;
        public Spaceport()
        {
            
        }
        
        public string LocationName { get => locationName; set => locationName = value; }
        public double Latitude { get => lattitude; set => lattitude = value; } // api request could be made to get the lattitude of the location

        public int CompareTo(ISpaceport? other)
        {
            int distanceComparison = DistanceToEquator().CompareTo(other.DistanceToEquator());
            if (distanceComparison != 0)
            {
                return distanceComparison;
            }

            // Assuming WeatherCondition is a property in Spaceport that represents the weather condition.
            // Lower values are better.
            return this.WeatherCondition.CompareTo(y.WeatherCondition);

        }

        public double DistanceToEquator()
        {
            return Math.Abs(this.Latitude) * 111;
        }


    }
}
