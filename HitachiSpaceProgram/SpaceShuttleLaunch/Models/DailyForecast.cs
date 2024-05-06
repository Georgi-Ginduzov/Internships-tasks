using CsvHelper.Configuration.Attributes;
using System.Collections;

namespace SpaceShuttleLaunch.Models
{
    public class DailyForecast
    {
        public string Temperature { get; set; }

        public string WindSpeed { get; set; }

        public string Humidity { get; set; }

        public string Precipitation { get; set; }

        public string Lightning { get; set; }

        public string Clouds { get; set; }

        

       
    }
}
