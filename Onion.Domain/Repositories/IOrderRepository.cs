using Onion.Domain.Models;

namespace Onion.Domain.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetOrdersByUserIdAsync(int userId); // Kullanıcıya ait siparişleri getir
        Task<int> GetOrdersCountLastWeekAsync(); //haftalık sipariş sayısı
    }
}
