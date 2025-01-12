using AutoMapper;
using BlazorApp.Data.UnitOfWork.Interfaces;
using BlazorApp.Entities;
using BlazorApp.Services;
using Moq;
using Xunit;

namespace BlazorApp.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<ILogger<ProductService>> _mockLogger;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<ProductService>>();
            _mockMapper = new Mock<IMapper>();
            _productService = new ProductService(_mockUnitOfWork.Object, _mockLogger.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task CreateProductAsync_ShouldThrowException_WhenCategoryDoesNotExist()
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                CostPrice = 10.0m,
                CategoryId = Guid.NewGuid(),
                SupplierId = Guid.NewGuid()
            };

            _mockUnitOfWork.Setup(u => u.Categories.ExistsAsync(product.CategoryId))
                           .ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _productService.CreateProductAsync(product));
        }
         
    }
}
