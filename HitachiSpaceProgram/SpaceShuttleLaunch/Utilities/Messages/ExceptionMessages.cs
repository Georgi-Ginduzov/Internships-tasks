namespace SpaceShuttleLaunch.Utilities.Messages
{
    public class ExceptionMessages
    {
        // Path
        public const string DirectoryNotFoundException = "The current directory does not exist.";
        public const string PathIncorrect = "{0} path is not valid.";

        // IO
        public const string FileAlreadyOpen = "The file is already open in another process.";
        public const string NotEnoughDiskSpace = "There is not enough disk space to create or write to the file.";
        public const string ErrorWritingToFile = "An error occurred while writing to the CSV file.";
        public const string IOError = "An IO error occurred: {0}";

    }
}
