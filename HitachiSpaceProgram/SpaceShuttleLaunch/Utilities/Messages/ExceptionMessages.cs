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


        // Email
        public const string InvalidEmail = "Invalid email address! Please try again: ";
        public const string InvalidPassword = "Invalid password! Please try again. ";
        public const string InvalidRecipientEmail = "Invalid recipient email address! Please try again: ";
        public const string EmailNotSent = "The email was not sent. Please try again.";
        public const string MaxAttemptsReached = "You have reached the maximum number of attempts. Please try again later.";
        public const string EmailNotSentError = "An error occurred while sending the email: {0}";

        // SMTP
        public const string GeneralFailure = "General failure when sending the email.";
        public const string MailboxBusyOrUnavailable = "The recipient's mailbox is busy or unavailable.";
        public const string ExceededStorageAllocation = "The email is too large to fit in the recipient's mailbox.";
        public const string TransactionFailed = "The email transaction failed.";
        public const string ClientNotPermitted = "The client was not permitted to send the email.";

        // Forecast
        public const string NoForecastsAvailable = "No forecasts available.";
        public const string NotADailyForecast = "Object is not a DailyForecast.";


        // Repository
        public const string ModelCannotBeNull = "Model doesn't exist! It cannot be null.";

        // Spaceport
        public const string CannotBeNull = "{0} cannot be null. Please try again. ";
        public const string IsEmpty = "{0} is empty. Please try again. ";

        // Csv
        public const string CsvError = "An error occurred while reading to the CSV file: {0}";
        public const string CsvFileFormatException = "A format error occurred while parsing the data: {0}";
        public const string DataParsingError = "An overflow error occurred while parsing the data: {0}";

    }
}
