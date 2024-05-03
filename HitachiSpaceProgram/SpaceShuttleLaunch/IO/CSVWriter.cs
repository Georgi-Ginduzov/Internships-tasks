using SpaceShuttleLaunch.IO.Contracts;
using SpaceShuttleLaunch.Utilities.Messages;
using System.Globalization;

namespace SpaceShuttleLaunch.IO
{
    public class CSVWriter : IWriter
    {
        private readonly string filePath;

        public CSVWriter()
        {
            string resultsPath = Path.Combine(GetProjectDirectory(), "Utilities/Results");
            filePath = Path.Combine(resultsPath, "LaunchAnalysisReport.csv");

        }

        public void Write(string message)
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
                // Handle the case where the directory doesn't exist.
                // This might involve creating the directory and retrying the operation.

                throw new DirectoryNotFoundException(ExceptionMessages.DirectoryNotFoundException);
            }
            catch (IOException ex)
            {

                // is the file already open in another process
                // is there enough disk space to create or write to the file
                throw new IOException(ExceptionMessages.IOError, ex);
            }
        }

        public void Clear()
        {
            try
            {
                using (var streamWriter = new StreamWriter(filePath, false))
                {

                }
            }
            catch (IOException ex)
            {
                // Handle exception here.
                Console.WriteLine(ExceptionMessages.IOError, ex.Message);
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
                // TODO: Handle the case where the directory doesn't exist.
                throw new DirectoryNotFoundException(ExceptionMessages.DirectoryNotFoundException);
            }

        }


    }
}
