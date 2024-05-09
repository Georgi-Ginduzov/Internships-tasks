namespace SpaceShuttleLaunch.Services.Contracts
{
    public interface IEmail
    {
        bool Send(string recipientEmail, string subject, string body);
    }
}
