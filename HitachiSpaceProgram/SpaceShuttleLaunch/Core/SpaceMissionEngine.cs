using SpaceShuttleLaunch.Core.Contracts;
using SpaceShuttleLaunch.IO;
using SpaceShuttleLaunch.IO.Contracts;
using SpaceShuttleLaunch.Models;
using SpaceShuttleLaunch.Models.Contracts;

namespace SpaceShuttleLaunch.Core
{
    partial class SpaceMissionEngine : IEngine
    {
        private IWriter writer;
        private WeatherController weatherController;
        
        public SpaceMissionEngine()
        {
            writer = new WeatherCSVDataWriter();
            weatherController = new WeatherController();
        }

        public void Run()
        {
            Console.Write("Enter the path to the folder on the file system: ");
            string inputsFolderPath = Console.ReadLine();

            Console.Write("Enter the sender email: ");
            string senderEmail = Console.ReadLine();

            Console.Write("Enter the sender password: ");
            string senderPassword = Console.ReadLine();

            Console.Write("Enter the recipient email: ");
            string recipientEmail = Console.ReadLine();

            var spaceportsAndWeather = new SortedDictionary<IWeatherForecast, ISpaceport>();


            foreach (var filePath in Directory.EnumerateFiles(inputsFolderPath))
            {
                string location = Path.GetFileName(filePath);
                var spaceport = new Spaceport();
                spaceport.LocationName = location;
                

                IWeatherForecast mostSuitableForecast = weatherController.FindMostSuitableSpaceportForecast(filePath);

                spaceportsAndWeather[mostSuitableForecast] = spaceport;

            }

            foreach (var forecast in spaceportsAndWeather)
            {
                string spaceportName = forecast.Value.LocationName;
                string bestDate = forecast.Key.Date.ToString();
                writer.Write($"{spaceportName},{bestDate}");

            }

        }
    }
}
