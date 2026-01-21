using Onion.Domain.Models;

namespace Onion.Domain.Repositories
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Task<Cart> GetCartByUserIdAsync(int userId); // Kullanıcıya ait sepeti getir
        Task ClearCartAsync(int cartId); // Sepeti siler
    }
}
