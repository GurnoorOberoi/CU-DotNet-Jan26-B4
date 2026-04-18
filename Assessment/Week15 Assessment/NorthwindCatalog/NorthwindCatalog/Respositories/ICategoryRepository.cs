using NorthwindCatalog.DTOs;
using NorthwindCatalog.Models;

namespace NorthwindCatalog.Respositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
