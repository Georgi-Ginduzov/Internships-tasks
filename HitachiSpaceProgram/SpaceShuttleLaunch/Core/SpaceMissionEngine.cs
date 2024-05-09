using SpaceShuttleLaunch.Core.Contracts;
using SpaceShuttleLaunch.IO;
using SpaceShuttleLaunch.IO.Contracts;
using SpaceShuttleLaunch.Models;
using SpaceShuttleLaunch.Models.Contracts;
using SpaceShuttleLaunch.Repositories;

namespace SpaceShuttleLaunch.Core
{
    partial class SpaceMissionEngine : IEngine
    {
        private IWriter writer;
        private SpaceMissionController controller;
        
        public SpaceMissionEngine()
        {
            writer = new WeatherCSVDataWriter();
            controller = new SpaceMissionController();
        }

        public void Run()
        {
            Console.Write("Enter the path to the folder on the file system: ");
            string inputsFolderPath = Console.ReadLine();

            while (true)
            {
                var exists = Directory.Exists(inputsFolderPath);

                if (exists)
                    break;
                else
                {
                    Console.WriteLine("Wrong path! ");
                    Console.Write("Enter the path to the folder on the file system: ");
                    inputsFolderPath = Console.ReadLine();
                }
            }

            Console.Write("Enter the sender email: ");
            string senderEmail = Console.ReadLine();

            Console.Write("Enter the sender password: ");
            string senderPassword = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                senderPassword += key.KeyChar;
            }
            Console.WriteLine();

            Console.Write("Enter the recipient email: ");
            string recipientEmail = Console.ReadLine();



            foreach (var filePath in Directory.EnumerateFiles(inputsFolderPath))
            {
                string location = Path.GetFileName(filePath);                

                controller.FindMostSuitableSpaceportForecast(filePath, location);
            }
            
            foreach (var spaceport in controller.Spaceports.Models)
            {
                string spaceportName = spaceport.LocationName;
                string bestDate = spaceport.MostConvenientDayForLaunch.Date.ToString();

                writer.Write($"{spaceportName}, {bestDate}");

            }

        }
    }
}
