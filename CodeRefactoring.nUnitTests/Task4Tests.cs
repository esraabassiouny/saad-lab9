namespace CodeRefactoring.nUnitTests
{
    [TestFixture]
    public class Task4Tests
    {
        [Test]
        public void Fibonacci_WithNegativeInput_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Task4.Fibonacci(-1);
            });
        }

        [Test]
        public void Fibonacci_WithZeroAsInput_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Task4.Fibonacci(0));
        }

        [Test]
        public void Fibonacci_WithPositiveInput_ReturnsCorrectResult()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Task4.Fibonacci(1), Is.EqualTo(1));
                Assert.That(Task4.Fibonacci(2), Is.EqualTo(1));
                Assert.That(Task4.Fibonacci(3), Is.EqualTo(2));
                Assert.That(Task4.Fibonacci(4), Is.EqualTo(3));
                Assert.That(Task4.Fibonacci(5), Is.EqualTo(5));
                Assert.That(Task4.Fibonacci(6), Is.EqualTo(8));
                Assert.That(Task4.Fibonacci(7), Is.EqualTo(13));
                Assert.That(Task4.Fibonacci(8), Is.EqualTo(21));
            });
        }
    }
}