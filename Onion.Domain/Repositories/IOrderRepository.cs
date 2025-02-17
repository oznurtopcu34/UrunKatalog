using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetOrdersByUserIdAsync(int userId); // Kullanıcıya ait siparişleri getir
        Task<int> GetOrdersCountLastWeekAsync(); //haftalık sipariş sayısı
    }
}
