using Microsoft.EntityFrameworkCore;
using NorthwindCatalog.Data;
using NorthwindCatalog.Models;

namespace NorthwindCatalog.Respositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly NorthwindContext _context;

        public CategoryRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
