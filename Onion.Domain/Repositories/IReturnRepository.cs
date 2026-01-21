using Onion.Domain.Models;

namespace Onion.Domain.Repositories
{
    public interface IReturnRepository : IBaseRepository<Return>
    {
        Task<List<Return>> GetAllWithDetailsAsync(); // Tüm iade taleplerini ilişkili verilerle getir
    }
}
