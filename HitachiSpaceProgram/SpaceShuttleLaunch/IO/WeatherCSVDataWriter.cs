using SpaceShuttleLaunch.Utilities.Messages;
using System.Globalization;

namespace SpaceShuttleLaunch.IO
{
    public class WeatherCSVDataWriter : CSVWriter
    {
        private readonly string filePath;

        public WeatherCSVDataWriter()
        {
            string resultsPath = Path.Combine(GetProjectDirectory(), "Utilities/Results");
            filePath = Path.Combine(resultsPath, "LaunchAnalysisReport.csv");

        }

        public override void Write(string message)
        {
            try
            {
                using (var streamWriter = new StreamWriter(filePath, true))
                using (var csvWriter = new CsvHelper.CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteField(message);
                    csvWriter.NextRecord();
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException(ExceptionMessages.DirectoryNotFoundException);
            }
            catch (IOException ex)
            {
                throw new IOException(ExceptionMessages.IOError, ex);
            }
        }

        public override void ClearData()
        {
            try
            {
                using (var streamWriter = new StreamWriter(filePath, false))
                {

                }
            }
            catch (IOException ex)
            {
                throw new IOException(ExceptionMessages.IOError, ex);
            }
        }

        private string GetProjectDirectory()
        {
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var directoryName = Path.GetFileName(currentDirectory);
                var relativePath = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;
                return relativePath;
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException(ExceptionMessages.DirectoryNotFoundException);
            }

        }

    }
}
