using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ProductDbContext context) : base(context) { }
    }
   
}
