
using Moq;

namespace CodeRefactoring.nUnitTests
{
    [TestFixture]
    public class Task2Tests
    {
        [Test]
        public void SendNotification_ValidParameters_EmailSent()
        {
            // Arrange
            var emailService = new EmailService();
            var userId = "123";
            var message = "Test message";

            // Act
            using (var consoleOutput = new ConsoleOutput())
            {
                emailService.SendNotification(userId, message);

                // Assert
                // Verify that the expected output is written to the console
                var output = consoleOutput.GetOutput();
                Assert.That(output, Contains.Substring($"Sending email notification to user {userId}: {message}"));
            }
        }

        [Test]
        public void SendNotification_ValidParameters_SmsSent()
        {
            // Arrange
            var smsService = new SmsService();
            var userId = "123";
            var message = "Test message";

            // Act
            using (var consoleOutput = new ConsoleOutput())
            {
                smsService.SendNotification(userId, message);

                // Assert
                // Verify that the expected output is written to the console
                var output = consoleOutput.GetOutput();
                Assert.That(output, Contains.Substring($"Sending SMS notification to user {userId}: {message}"));
            }
        }

        [Test]
        public void SendNotification_ValidParameters_PushNotificationSent()
        {
            // Arrange
            var pushNotificationService = new PushNotificationService();
            var userId = "123";
            var message = "Test message";

            // Act
            using (var consoleOutput = new ConsoleOutput())
            {
                pushNotificationService.SendNotification(userId, message);

                // Assert
                // Verify that the expected output is written to the console
                var output = consoleOutput.GetOutput();
                Assert.That(output, Contains.Substring($"Sending push notification to user {userId}: {message}"));
            }
        }
    }
}