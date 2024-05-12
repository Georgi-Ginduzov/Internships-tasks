namespace SpaceShuttleLaunch.Services.Contracts
{
    public interface IEmail
    {
        Task<bool> SendAsync(string recipientEmail, string subject, string body, string attachmentLocation);
    }
}
