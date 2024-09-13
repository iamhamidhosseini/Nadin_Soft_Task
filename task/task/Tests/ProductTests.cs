using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task.Data;
using task.Features;
using Xunit;

namespace task.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Test_CreateProductCommand()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            var context = new ApplicationDbContext(options);
            var handler = new CreateProductCommandHandler(context);

            // Act
            var command = new CreateProductCommand { Name = "Test", ProduceDate = DateTime.Now, ManufacturePhone = "1234567890", ManufactureEmail = "test@example.com", IsAvailable = true };
            var productId = handler.Handle(command, CancellationToken.None).Result;

            // Assert
            var product = context.Products.Find(productId);
            Assert.NotNull(product);
        }
    }

}
