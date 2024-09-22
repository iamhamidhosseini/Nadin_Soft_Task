using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;
using task.Data;
using task.Features;
using Xunit;

namespace task.Tests
{
    public class ProductTests
    {
        [Fact]
        public async Task Test_CreateProductCommand()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>(); // Use the repository interface
            var handler = new CreateProductCommandHandler(mockRepository.Object);

            var command = new CreateProductCommand
            {
                Name = "Hamid",
                ProduceDate = DateTime.Now,
                ManufacturePhone = "09044528184",
                ManufactureEmail = "iamhamidhosseini@gmail.com",
                IsAvailable = true
            };

            // Act
            var productId = await handler.Handle(command, CancellationToken.None);

            // Assert
            mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);
            Assert.True(productId > 0); // Assuming the product ID is generated and greater than 0
        }
    }

}
