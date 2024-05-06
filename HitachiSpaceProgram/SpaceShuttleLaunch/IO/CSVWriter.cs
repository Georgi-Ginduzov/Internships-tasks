using SpaceShuttleLaunch.IO.Contracts;
using SpaceShuttleLaunch.Utilities.Messages;
using System.Globalization;

namespace SpaceShuttleLaunch.IO
{
    public abstract class CSVWriter : IWriter
    {
        private readonly string filePath;

        public CSVWriter()
        {
            string resultsPath = Path.Combine(GetProjectDirectory(), "Utilities/Results");
            filePath = Path.Combine(resultsPath, "LaunchAnalysisReport.csv");

        }

        public abstract void Write(string message);

        public abstract void ClearData();

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
