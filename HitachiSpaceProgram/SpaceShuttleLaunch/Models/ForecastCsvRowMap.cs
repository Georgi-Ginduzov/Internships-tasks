using CsvHelper.Configuration;

namespace SpaceShuttleLaunch.Models
{
    public class ForecastCsvRowMap : ClassMap<WeatherCsvInput> // ForecastCsvRow
    {
        public ForecastCsvRowMap()
        {
            Map(x => x.Parameter).Index(0);
            /*Map(x => x.Days).Index(1).Convert(row =>
            {
                var columnValue = row.Row.GetField<string>("Days");
                return columnValue?.Split(',').ToList() ?? new List<string>();
            });*/

            Map(x => x.Days).Convert(row =>
            {
                var days = new List<string>();
                for (var i = 1; i < row.Row.HeaderRecord.Length; i++)
                {
                    days.Add(row.Row.GetField(i));
                }
                return days;
            });
        }
    }
}
