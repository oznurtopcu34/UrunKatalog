using Onion.Application.Model.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.OrderService
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(int userId); // Sipariş oluştur
        Task<List<Order_DTO>> GetOrdersByUserIdAsync(int userId); // Kullanıcıya ait siparişleri getir
        Task<int> GetOrdersCountLastWeekAsync(); //haftalık alınan sipariş sayıları
    }
}
