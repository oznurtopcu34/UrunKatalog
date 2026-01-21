using Onion.Domain.Models;

namespace Onion.Domain.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> GetCategoryByNameAsync(string categoryName); //kategori adına göre arama
    
    }
}
