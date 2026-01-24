using Microsoft.EntityFrameworkCore;
using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ProductDbContext context) : base(context) { }

        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _table
                .Include(o => o.OrderItems) // Sipariş ürünlerini dahil et
                    .ThenInclude(oi => oi.Product) // Ürün detaylarını dahil et
                .Where(o => o.UserID == userId)
                .ToListAsync();
        }

        public async Task<int> GetOrdersCountLastWeekAsync()
        {
            var lastWeek = DateTime.Now.AddDays(-7);
            return await _table
                .Where(o => o.OrderDate >= lastWeek)
                .CountAsync();
        }

    }
  
}
