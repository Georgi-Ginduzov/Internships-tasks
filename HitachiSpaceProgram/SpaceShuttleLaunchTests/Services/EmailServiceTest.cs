using SpaceShuttleLaunch.Services;

namespace SpaceShuttleLaunchTests.Services
{
    public class EmailServiceTest
    {
        [Test]
        public void TestSendEmailWithValidParameters()
        {
            var emailService = new EmailService("sender@gmail.com", "password");
            var result = emailService.Send("recipient@gmail.com", "subject", "text", "attachment.txt");
            Assert.IsTrue(result);
        }

        [Test]
        public void TestSendEmailWithInvalidRecipientEmail()
        {
            var emailService = new EmailService("sender@gmail.com", "password");
            var result = emailService.Send("invalid email", "subject", "text", "attachment.txt");
            Assert.IsFalse(result);
        }

        [Test]
        public void TestSendEmailWithInvalidAttachmentLocation()
        {
            var emailService = new EmailService("sender@gmail.com", "password");
            var result = emailService.Send("recipient@gmail.com", "subject", "text", "invalid path");
            Assert.IsFalse(result);
        }


    }
}
