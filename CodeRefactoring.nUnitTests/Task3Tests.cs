using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace CodeRefactoring.nUnitTests
{
    [TestFixture]
    public class Task3Tests
    {
        [Test]
        public void SellBook_WhenQuantityIsSufficient_ReduceQuantity()
        {
            // Arrange
            var book = new BookStoreItemManager
            {
                Title = "Sample Book",
                Quantity = 10
            };
            var quantityToSell = 5;

            // Act
            book.SellBook(quantityToSell);

            // Assert
            Assert.That(book.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void SellBook_WhenQuantityIsInsufficient_DoNotReduceQuantity()
        {
            // Arrange
            var book = new BookStoreItemManager
            {
                Title = "Sample Book",
                Quantity = 5
            };
            var quantityToSell = 10;

            // Act
            book.SellBook(quantityToSell);

            // Assert
            Assert.That(book.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void RestockBook_IncreaseQuantity()
        {
            // Arrange
            var book = new BookStoreItemManager
            {
                Title = "Sample Book",
                Quantity = 5
            };
            var quantityToRestock = 10;

            // Act
            book.RestockBook(quantityToRestock);

            // Assert
            Assert.That(book.Quantity, Is.EqualTo(15));
        }

        [Test]
        public void BorrowBook_WhenBookIsAvailable_MarkAsNotAvailable()
        {
            // Arrange
            var book = new LibraryItemManager
            {
                Title = "Sample Book",
                IsAvailable = true
            };

            // Act
            book.BorrowBook();

            // Assert
            Assert.That(book.IsAvailable, Is.False);
        }

        [Test]
        public void BorrowBook_WhenBookIsNotAvailable_DoNotChangeAvailability()
        {
            // Arrange
            var book = new LibraryItemManager
            {
                Title = "Sample Book",
                IsAvailable = false
            };

            // Act
            book.BorrowBook();

            // Assert
            Assert.That(book.IsAvailable, Is.False);
        }

        [Test]
        public void ReturnBook_WhenBookIsNotAvailable_MarkAsAvailable()
        {
            // Arrange
            var book = new LibraryItemManager
            {
                Title = "Sample Book",
                IsAvailable = false
            };

            // Act
            book.ReturnBook();

            // Assert
            Assert.That(book.IsAvailable, Is.True);
        }

        [Test]
        public void ReturnBook_WhenBookIsAvailable_DoNotChangeAvailability()
        {
            // Arrange
            var book = new LibraryItemManager
            {
                Title = "Sample Book",
                IsAvailable = true
            };

            // Act
            book.ReturnBook();

            // Assert
            Assert.That(book.IsAvailable, Is.True);
        }

        [Test]
        public void BookStoreManager_DisplayBookInfo_ShouldOutputCorrectInformation()
        {
            // Arrange
            var bookStoreItemManager = new BookStoreItemManager
            {
                Title = "Sample Book",
                Author = "John Doe",
                Price = 9.99m,
                Quantity = 5
            };

            // Act (Redirect Console.WriteLine output for testing)
            using (var consoleOutput = new ConsoleOutput())
            {
                bookStoreItemManager.DisplayBookInfo();

                var result = consoleOutput.GetOutput().Split("\r\n");

                // Assert
                Assert.Multiple(() =>
                {
                    Assert.That(result[0], Is.EqualTo($"Title: {bookStoreItemManager.Title}"));
                    Assert.That(result[1], Is.EqualTo($"Author: {bookStoreItemManager.Author}"));
                    Assert.That(result[2], Is.EqualTo($"Price: {bookStoreItemManager.Price:C}"));
                    Assert.That(result[3], Is.EqualTo($"Quantity: {bookStoreItemManager.Quantity}"));
                });
            }
        }

        [Test]
        public void LibraryManager_DisplayBookInfo_ShouldOutputCorrectInformation()
        {
            // Arrange
            var libraryItemManager = new LibraryItemManager
            {
                Title = "Sample Book",
                Author = "John Doe",
                Year = 2021,
                IsAvailable = true
            };

            // Act (Redirect Console.WriteLine output for testing)
            using (var consoleOutput = new ConsoleOutput())
            {
                libraryItemManager.DisplayBookInfo();
                var result = consoleOutput.GetOutput().Split("\r\n");

                // Assert
                Assert.Multiple(() =>
                {
                    Assert.That(result[0], Is.EqualTo($"Title: {libraryItemManager.Title}"));
                    Assert.That(result[1], Is.EqualTo($"Author: {libraryItemManager.Author}"));
                    Assert.That(result[2], Is.EqualTo($"Year: {libraryItemManager.Year}"));
                    Assert.That(result[3], Is.EqualTo($"Availability: {(libraryItemManager.IsAvailable ? "Available" : "Not Available")}"));
                });
            }
        }
    }
}