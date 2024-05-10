using SpaceShuttleLaunch.Core.Contracts;
using SpaceShuttleLaunch.IO;
using SpaceShuttleLaunch.IO.Contracts;
using SpaceShuttleLaunch.Utilities.Messages;

namespace SpaceShuttleLaunch.Core
{
    partial class SpaceMissionEngine : IEngine
    {
        private IWriter writer;
        private SpaceMissionController controller;
        private readonly string attachmentLocation = "C:\\Users\\Asus\\source\\repos\\Internships-tasks\\HitachiSpaceProgram\\SpaceShuttleLaunch\\Utilities\\Results\\LaunchAnalysisReport.csv";
        
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
            string senderPassword = Console.ReadLine();

            Console.Write("Enter the recipient email: ");
            string recipientEmail = Console.ReadLine();



            foreach (var filePath in Directory.EnumerateFiles(inputsFolderPath))
            {
                string location = Path.GetFileName(filePath);

                try
                {
                    controller.FindMostSuitableSpaceportForecast(filePath, location);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine(ExceptionMessages.PathIncorrect, filePath);
                    Environment.Exit(1);
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine(ExceptionMessages.DirectoryNotFoundException, filePath);
                    Environment.Exit(1);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ExceptionMessages.IOError, ex.Message);
                    Environment.Exit(1);
                }
                catch (CsvHelper.CsvHelperException ex)
                {
                    Console.WriteLine(ExceptionMessages.CsvError, ex.Message);
                    Environment.Exit(1);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ExceptionMessages.CsvFileFormatException, ex.Message);
                    Environment.Exit(1);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ExceptionMessages.DataParsingError, ex.Message);
                    Environment.Exit(1);
                }
            }
            
            foreach (var spaceport in controller.Spaceports.Models)
            {
                string spaceportName = spaceport.LocationName;
                string bestDate = spaceport.MostConvenientDayForLaunch.Date.ToString();

                writer.Write($"{spaceportName}, {bestDate}");
            }

            string mailSubject = "Space Shuttle Launch";
            string mailBody = controller.Spaceports.Models.First().LocationName.ToString() + " on date -> " + controller.Spaceports.Models.First().MostConvenientDayForLaunch.Date.ToString();

            controller.SendEmailWithAttachment(senderEmail, senderPassword, recipientEmail, mailSubject, mailBody, attachmentLocation);

        }
    }
}
