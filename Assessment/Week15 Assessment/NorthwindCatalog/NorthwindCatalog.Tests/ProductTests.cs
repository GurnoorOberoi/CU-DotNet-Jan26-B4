using NorthwindCatalog.DTOs;

namespace NorthwindCatalog.Tests
{
    public class ProductTests
    {
        [Fact]
        public void InventoryValue_Should_Return_Correct_Value()
        {
            var product = new ProductDto
            {
                UnitPrice = 20,
                UnitsInStock = 5
            };

            Assert.Equal(100, product.InventoryValue);
        }
    }
}