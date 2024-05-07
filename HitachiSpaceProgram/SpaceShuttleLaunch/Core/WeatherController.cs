using SpaceShuttleLaunch.Models;
using SpaceShuttleLaunch.Models.Contracts;
using SpaceShuttleLaunch.Models.LaunchWeatherCriteria;
using SpaceShuttleLaunch.Repositories;
using System.Globalization;

namespace SpaceShuttleLaunch.Core
{
    public class WeatherController
    {

        private WeatherForecastsRepository forecasts;


        public WeatherController()
        {
            forecasts = new WeatherForecastsRepository();
        }

        public IWeatherForecast MostSuitableStationForecast { get => forecasts.MostSuitableForecast; }

        public IWeatherForecast FindMostSuitableSpaceportForecast(string filePath)
        {
            FindValidDays(filePath);

            return MostSuitableStationForecast;
        }

        public void FindValidDays(string filePath)
        {
            var dailyForecasts =  GetWeatherData(filePath);

            var criteria = new List<IWeatherCriteria>
            {
                new TemperatureCriteria(),
                new WindSpeedCriteria(),
                new HumidityCriteria(),
                new PrecipitationCriteria(),
                new LightningCriteria(),
                new CloudsCriteria()
            };

            var weatherCriteria = new WeatherCriteria(criteria);

            foreach (var forecast in dailyForecasts)
            {
                if (weatherCriteria.IsWeatherSuitable(forecast))
                {
                    forecasts.Add(forecast);
                }
            }

        }

        public string GetInputFileLocation()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryName = Path.GetFileName(currentDirectory);
            var relativePath = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;

            string resultsPath = Path.Combine(relativePath, "Utilities/InputFiles");
            string filePath = Path.Combine(resultsPath, "Input.csv");

            return filePath;
        }

        public DailyForecast[] GetWeatherData(string filePath)
        {
            int forecastsCount = 15;
            DailyForecast[] dailyForecasts = new DailyForecast[forecastsCount];
            for (int j = 0; j < dailyForecasts.Length; j++)
            {
                dailyForecasts[j] = new DailyForecast();
                dailyForecasts[j].Date = j + 1;
            }

            using var reader = new StreamReader(filePath);
            using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<WeatherCsvInput>();

                foreach (var parameter in records)
                {
                    int i = 0;

                    switch (parameter.Parameter)
                    {
                        case "Temperature (C)":
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day1);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day2);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day3);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day4);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day5);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day6);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day7);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day8);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day9);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day10);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day11);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day12);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day13);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day14);
                            dailyForecasts[i++].Temperature = float.Parse(parameter.Day15);

                            break;
                        case "Humidity (%)":
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day1);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day2);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day3);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day4);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day5);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day6);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day7);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day8);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day9);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day10);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day11);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day12);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day13);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day14);
                            dailyForecasts[i++].Humidity = int.Parse(parameter.Day15);
                            break;
                        case "Wind (m/s)":
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day1);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day2);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day3);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day4);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day5);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day6);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day7);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day8);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day9);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day10);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day11);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day12);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day13);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day14);
                            dailyForecasts[i++].WindSpeed = float.Parse(parameter.Day15);
                            break;
                        case "Precipitation (%)":
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day1);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day2);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day3);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day4);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day5);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day6);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day7);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day8);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day9);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day10);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day11);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day12);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day13);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day14);
                            dailyForecasts[i++].Precipitation = int.Parse(parameter.Day15);
                            break;
                        case "Lightning":
                            dailyForecasts[i++].Lightning = parameter.Day1;
                            dailyForecasts[i++].Lightning = parameter.Day2;
                            dailyForecasts[i++].Lightning = parameter.Day3;
                            dailyForecasts[i++].Lightning = parameter.Day4;
                            dailyForecasts[i++].Lightning = parameter.Day5;
                            dailyForecasts[i++].Lightning = parameter.Day6;
                            dailyForecasts[i++].Lightning = parameter.Day7;
                            dailyForecasts[i++].Lightning = parameter.Day8;
                            dailyForecasts[i++].Lightning = parameter.Day9;
                            dailyForecasts[i++].Lightning = parameter.Day10;
                            dailyForecasts[i++].Lightning = parameter.Day11;
                            dailyForecasts[i++].Lightning = parameter.Day12;
                            dailyForecasts[i++].Lightning = parameter.Day13;
                            dailyForecasts[i++].Lightning = parameter.Day14;
                            dailyForecasts[i++].Lightning = parameter.Day15;
                            break;
                        case "Clouds":
                            dailyForecasts[i++].Clouds = parameter.Day1;
                            dailyForecasts[i++].Clouds = parameter.Day2;
                            dailyForecasts[i++].Clouds = parameter.Day3;
                            dailyForecasts[i++].Clouds = parameter.Day4;
                            dailyForecasts[i++].Clouds = parameter.Day5;
                            dailyForecasts[i++].Clouds = parameter.Day6;
                            dailyForecasts[i++].Clouds = parameter.Day7;
                            dailyForecasts[i++].Clouds = parameter.Day8;
                            dailyForecasts[i++].Clouds = parameter.Day9;
                            dailyForecasts[i++].Clouds = parameter.Day10;
                            dailyForecasts[i++].Clouds = parameter.Day11;
                            dailyForecasts[i++].Clouds = parameter.Day12;
                            dailyForecasts[i++].Clouds = parameter.Day13;
                            dailyForecasts[i++].Clouds = parameter.Day14;
                            dailyForecasts[i++].Clouds = parameter.Day15;
                            break;

                        default:
                            break;
                    }
                }
            }

            return dailyForecasts;
        }

        


    }
}
