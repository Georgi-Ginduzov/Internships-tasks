using SpaceShuttleLaunch.Core.Contracts;
using SpaceShuttleLaunch.Models;
using SpaceShuttleLaunch.Models.Contracts;
using SpaceShuttleLaunch.Models.LaunchWeatherCriteria;
using SpaceShuttleLaunch.Repositories;
using SpaceShuttleLaunch.Services;
using System.Globalization;

namespace SpaceShuttleLaunch.Core
{
    public class SpaceMissionController : ISpaceMissionController
    {   
        private SpaceportRepository spaceports;


        public SpaceMissionController()
        {
            spaceports = new SpaceportRepository();
        }

        public SpaceportRepository Spaceports => spaceports;

        public bool SendEmail(string senderEmail, string senderPassword, string recipientEmail, string subject, string body)
        {
            try
            {
                var emailService = new EmailService(senderEmail, senderPassword);
                emailService.Send(recipientEmail, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // handle exception
                return false;
            }

            return true;
        }
        
        public void FindMostSuitableSpaceportForecast(string filePath, string spaceportLocation)
        {
            var forecastRepository =  GetWeatherData(filePath);
            var validForecasts = new WeatherForecastsRepository();

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

            foreach (var forecast in forecastRepository.Models)
            {
                if (weatherCriteria.IsWeatherSuitable(forecast))
                {
                    validForecasts.Add(forecast);
                }
            }

            spaceports.Add(new Spaceport(spaceportLocation, validForecasts));
        }

        //public delegate void UpdatePropertyDelegate(DailyForecast forecast, string value);
        /*public DailyForecast[] GetWeatherData(string filePath)
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
                var records = csv.GetRecords<dynamic>();

                Dictionary<string, UpdatePropertyDelegate> propertyDelegates = new Dictionary<string, UpdatePropertyDelegate>
                {
                    { "Temperature (C)", (forecast, value) => forecast.Temperature = float.Parse(value) },
                    { "Humidity (%)", (forecast, value) => forecast.Humidity = int.Parse(value) },
                    { "Wind (m/s)", (forecast, value) => forecast.WindSpeed = float.Parse(value) },
                    { "Precipitation (%)", (forecast, value) => forecast.Precipitation = int.Parse(value) },
                    { "Lightning", (forecast, value) => forecast.Lightning = value },
                    { "Clouds", (forecast, value) => forecast.Clouds = value }
                };

                foreach (var parameter in records)
                {
                    //propertyDelegates[parameter.Key] = parameter.Value;
                    int i = 0;
                    foreach (var item in parameter)
                    {
                        //var operation = propertyDelegates["Temperature (C)"](dailyForecasts[i++], item.Value);
                        propertyDelegates["Temperature (C)"](dailyForecasts[i++], item.Value);

                        switch (item.Value.ToString())
                        {
                            case "Humidity (%)":
                                break;
                            case "Wind (m/s)":
                                break;
                            case "Precipitation (%)":
                                break;
                            case "Lightning":
                                break;
                            case "Clouds":
                                break;

                            default:
                                //operation++;
                                break;
                        }
                    }

                    if (propertyDelegates.ContainsKey(parameter.Parameter))
                    {
                        propertyDelegates[parameter.Parameter](dailyForecasts[i], parameter.Day1);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 1], parameter.Day2);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 2], parameter.Day3);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 3], parameter.Day4);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 4], parameter.Day5);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 5], parameter.Day6);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 6], parameter.Day7);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 7], parameter.Day8);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 8], parameter.Day9);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 9], parameter.Day10);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 10], parameter.Day11);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 11], parameter.Day12);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 12], parameter.Day13);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 13], parameter.Day14);
                        propertyDelegates[parameter.Parameter](dailyForecasts[i + 14], parameter.Day15);
                    }
                }
            }

            return dailyForecasts;
        }*/

        public WeatherForecastsRepository GetWeatherData(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    int forecastsCount = 15;
                    DailyForecast[] dailyForecasts = new DailyForecast[forecastsCount];
                    for (int j = 0; j < dailyForecasts.Length; j++)
                    {
                        dailyForecasts[j] = new DailyForecast();
                        dailyForecasts[j].Date = j + 1;
                    }

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

                    WeatherForecastsRepository forecasts = new WeatherForecastsRepository();

                    foreach (var forecast in dailyForecasts)
                    {
                        forecasts.Add(forecast);
                    }

                    return forecasts;
                }

            }

        }




    }
}
