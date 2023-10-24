namespace CodeRefactoring.nUnitTests
{
    [TestFixture]
    public class Task2Tests
    {
        private User user;

        [Test]
        public void Notify_WithValidEmailService_ShouldSendEmailNotification()
        {
            // Arrange
            string userId = "123";
            string message = "Hello, this is an email notification.";
            user = new User(userId, new EmailService());

            // Act (Redirect Console.WriteLine output for testing)
            using (var consoleOutput = new ConsoleOutput())
            {
                user.Notify(message);

                var result = consoleOutput.GetOutput();

                // Assert
                Assert.Multiple(() =>
                {
                    Assert.That(result, Is.EqualTo($"Sending email notification to user {userId}: {message}"));

                });
            }
        }

        [Test]
        public void Notify_WithValidSmsService_ShouldSendSmsNotification()
        {
            // Arrange
            string userId = "123";
            string message = "Hello, this is an SMS notification.";
            user = new User(userId, new SmsService());

            // Act (Redirect Console.WriteLine output for testing)
            using (var consoleOutput = new ConsoleOutput())
            {
                user.Notify(message);

                var result = consoleOutput.GetOutput();

                // Assert
                Assert.Multiple(() =>
                {
                    Assert.That(result, Is.EqualTo($"Sending SMS notification to user {userId}: {message}"));

                });
            }
        }

        [Test]
        public void Notify_WithValidPushNotificationService_ShouldSendPushNotification()
        {
            // Arrange
            string userId = "123";
            string message = "Hello, this is a push notification.";
            user = new User(userId, new PushNotificationService());

            // Act (Redirect Console.WriteLine output for testing)
            using (var consoleOutput = new ConsoleOutput())
            {
                user.Notify(message);

                var result = consoleOutput.GetOutput();

                // Assert
                Assert.Multiple(() =>
                {
                    Assert.That(result, Is.EqualTo($"Sending push notification to user {userId}: {message}"));

                });
            }
        }

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