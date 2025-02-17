using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Repositories
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Task<Cart> GetCartByUserIdAsync(int userId); // Kullanıcıya ait sepeti getir
        Task ClearCartAsync(int cartId); // Sepeti siler
    }
}
