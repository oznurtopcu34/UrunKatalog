using Microsoft.EntityFrameworkCore;
using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductDbContext context) : base(context) { }
        public async Task<Category> GetCategoryByNameAsync(string categoryName)
        {
            return await _context.Categories
                                 .FirstOrDefaultAsync(c => c.CategoryName.ToLower() == categoryName.ToLower());
        }
    }
   
}
