using NorthwindCatalog.DTOs;
using NorthwindCatalog.Models;

namespace NorthwindCatalog.Respositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync();
    }
}
