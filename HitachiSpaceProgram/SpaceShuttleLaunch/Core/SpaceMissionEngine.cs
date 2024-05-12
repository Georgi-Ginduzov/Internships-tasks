using SpaceShuttleLaunch.Core.Contracts;
using SpaceShuttleLaunch.IO;
using SpaceShuttleLaunch.IO.Contracts;
using SpaceShuttleLaunch.Utilities.Messages;
using System.Globalization;

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

        private void SetCulture()
        {
            Console.Write(OutputMessages.PreferredLanguage);
            string preferredLanguage = Console.ReadLine();
           
            switch (preferredLanguage.ToLower())
            {
                case "german":
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
                    break;

                default:
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
                    break;
            }

        }

        public void Run()
        {
            SetCulture();

            Console.Write(OutputMessages.EnterInputFolderPath);
            string inputsFolderPath = Console.ReadLine();

            while (true)
            {
                if (Directory.Exists(inputsFolderPath))
                    break;
                else
                {
                    Console.WriteLine(ExceptionMessages.PathIncorrect, inputsFolderPath);
                    Console.Write(OutputMessages.EnterInputFolderPath);
                    inputsFolderPath = Console.ReadLine();
                }
            }

            Console.Write(OutputMessages.EnterInputSenderEmail);
            string senderEmail = Console.ReadLine();

            Console.Write(OutputMessages.EnterInputSenderPassword);
            string senderPassword = Console.ReadLine();

            Console.Write(OutputMessages.EnterInputRecipientEmail);
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
            string mailBody = controller.Spaceports.Models.First().LocationName.ToString() + "  -> " + controller.Spaceports.Models.First().MostConvenientDayForLaunch.Date.ToString();

            controller.SendEmailWithAttachment(senderEmail, senderPassword, recipientEmail, mailSubject, mailBody, attachmentLocation);

        }
    }
}
