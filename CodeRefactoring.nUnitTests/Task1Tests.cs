
namespace CodeRefactoring.nUnitTests
{
    [TestFixture]
    public class Task1Tests
    {
        [Test]
        public void Login_Successful()
        {
            // Arrange
            var loginSystem = new Task1();
            const string correctPassword = "password123";

            // Act
            bool loginResult = loginSystem.Login(correctPassword);

            // Assert
            Assert.That(loginResult, Is.True);
        }

        [Test]
        public void Login_Unsuccessful()
        {
            // Arrange
            var loginSystem = new Task1();
            const string incorrectPassword = "wrongpassword";

            // Act
            bool loginResult = loginSystem.Login(incorrectPassword);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(loginResult, Is.False);
                Assert.That(loginSystem.CurrentAttempt, Is.EqualTo(1));
            });
        }

        [Test]
        public void Login_Lockout()
        {
            // Arrange
            var loginSystem = new Task1();
            const string incorrectPassword = "wrongpassword";
            const string correctPassword = "password123";

            // Act
            for (int i = 0; i < 3; i++)
            {
                loginSystem.Login(incorrectPassword);
            }
            bool loginResult = loginSystem.Login(correctPassword);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(loginResult, Is.False);
                Assert.That(loginSystem.IsLockedOut, Is.True);
            });
        }
    }
}