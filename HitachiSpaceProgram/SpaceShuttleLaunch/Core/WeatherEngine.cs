using SpaceShuttleLaunch.Core.Contracts;
using SpaceShuttleLaunch.IO;
using SpaceShuttleLaunch.IO.Contracts;
using SpaceShuttleLaunch.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SpaceShuttleLaunch.Core
{
    public class WeatherEngine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ISpaceMissionController controller;
        private Spaceport spaceport;

        public WeatherEngine(string weatherFolderPath)
        {
            reader = new WeatherCSVDataReader(weatherFolderPath);
            writer = new WeatherCSVDataWriter();
            controller = new SpaceMissionController();

            spaceport = new Spaceport(); // ???
        }

        public void Run()
        {
            string filePath;
            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryName = Path.GetFileName(currentDirectory);
            var relativePath = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;

            string resultsPath = Path.Combine(relativePath, "Utilities/Results");
            filePath = Path.Combine(resultsPath, "Test.csv");

            GetWeatherData(filePath);
        }

        /*public static List<string> ReadInCSV(string absolutePath)
        {
            IEnumerable<string> allValues;

            using (TextReader fileReader = File.OpenText(absolutePath))
            {
                var csv = new CsvHelper.CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = false;
                allValues = csv.GetRecords<string>
            }

            return allValues.ToList<string>();
        }*/

        public void GetWeatherData(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var rows = csv.GetRecords<WeatherCsvInput>();
                    var forecasts = rows.ToDictionary(x => x.Parameter, x => x.Days);
                    ;
                    /*var records = csv.GetRecords<WeatherCsvInput>();
                    const int days = 15;
                    var forecasts = new List<DailyForecast>(days);


                    for (int i = 0; i < days; i++)
                    {
                        forecasts[i].Temperature =
                            records
                            .ElementAt(0)
                            .Days[i];
                        forecasts[i].WindSpeed =
                            records
                            .ElementAt(1)
                            .Days[i];
                        forecasts[i].Humidity =
                            records
                            .ElementAt(2)
                            .Days[i];
                        forecasts[i].Precipitation =
                            records
                            .ElementAt(3)
                            .Days[i];
                        forecasts[i].Lightning =
                            records
                            .ElementAt(4)
                            .Days[i];
                        forecasts[i].Clouds =
                            records
                            .ElementAt(5)
                            .Days[i];
                    }*/
                }
            }
            
        }

        public void GetWeatherDataa(string filePath)
        {
            /*var weatherData = reader.ReadData();

            foreach (var data in weatherData)
            {
                writer.Write(data);
            }*/

            const int BufferSize = 128;

            /*using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // Process line
                }
            }*/
        }

        public void GetWeatherDataCSV()
        {
            string filePath;
            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryName = Path.GetFileName(currentDirectory);
            var relativePath = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;

            string resultsPath = Path.Combine(relativePath, "Utilities/Results");
            filePath = Path.Combine(resultsPath, "Test.csv"); //"LaunchAnalysisReport.csv");

            using var reader = new StreamReader(filePath);
            using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<DailyForecast>();

                foreach (var record in records)
                {
                    spaceport.AddForecast(record);
                }

              

                ;
            }
        }

        public List<DailyForecast> ReadCsvFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<DailyForecast>().ToList();

                var transposedRecords = new List<DailyForecast>();



                for (int i = 0; i < 15; i++)
                {
                    var transposedRecord = new DailyForecast
                    {
                        Temperature = records[0].GetType().GetProperty($"Day{i + 1}").GetValue(records[0]) as string,
                        WindSpeed = records[1].GetType().GetProperty($"Day{i + 1}").GetValue(records[1]) as string,
                        Humidity = records[2].GetType().GetProperty($"Day{i + 1}").GetValue(records[2]) as string,
                        Precipitation = records[3].GetType().GetProperty($"Day{i + 1}").GetValue(records[3]) as string,
                        Lightning = records[4].GetType().GetProperty($"Day{i + 1}").GetValue(records[4]) as string,
                        Clouds = records[5].GetType().GetProperty($"Day{i + 1}").GetValue(records[5]) as string,
                        // ...and so on for the other properties...
                    };

                    transposedRecords.Add(transposedRecord);
                }

                return transposedRecords;
            }
        }


    }
}
