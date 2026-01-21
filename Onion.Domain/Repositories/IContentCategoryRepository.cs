using Onion.Domain.Models;

namespace Onion.Domain.Repositories
{
    public interface IContentCategoryRepository:IBaseRepository<ContentCategory>
    {
        Task<ContentCategory> GetContentCategoryByNameAsync(string categoryName);//kategori adına göre arama
    }
}
