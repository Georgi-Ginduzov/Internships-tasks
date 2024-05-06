using CsvHelper.Configuration.Attributes;
using System.Collections;

namespace SpaceShuttleLaunch.Models
{
    public class WeatherCsvInput //: IComparable<WeatherCsvInput>//, IEnumerable
    {
        [Index(0)]
        public string Parameter { get; set; }

        [Index(1, -1)]
        public List<string> Days { get; set; }

        /*public WeatherCsvInput()
        {
            Days = new List<string>();
        }*/

        /*[Name("1")]// make this a list of days??? how to do this?
        public string Day1 { get; set; }

        [Name("2")]
        public string Day2 { get; set; }

        [Name("3")]
        public string Day3 { get; set; }

        [Name("4")]
        public string Day4 { get; set; }

        [Name("5")]
        public string Day5 { get; set; }

        [Name("6")]
        public string Day6 { get; set; }

        [Name("7")]
        public string Day7 { get; set; }

        [Name("8")]
        public string Day8 { get; set; }

        [Name("9")]
        public string Day9 { get; set; }

        [Name("10")]
        public string Day10 { get; set; }

        [Name("11")]
        public string Day11 { get; set; }

        [Name("12")]
        public string Day12 { get; set; }

        [Name("13")]
        public string Day13 { get; set; }

        [Name("14")]
        public string Day14 { get; set; }

        [Name("15")]
        public string Day15 { get; set; }*/


        public int CompareTo(WeatherCsvInput other)
        {
            // Compare by wind speed first, then by humidity
            /*int windComparison = WindSpeed.CompareTo(other.WindSpeed);
            if (windComparison == 0)
            {
                // If wind speeds are equal, compare by humidity
                return Humidity.CompareTo(other.Humidity);
            }
            else
            {
                return windComparison;
            }*/

            return 0;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
