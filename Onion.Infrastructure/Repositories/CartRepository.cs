using Microsoft.EntityFrameworkCore;
using Onion.Domain.Enums;
using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;


namespace Onion.Infrastructure.Repositories
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(ProductDbContext context) : base(context) { }

        public async Task<Cart> GetCartByUserIdAsync(int userId)
        {
            return await _table
                .Include(c => c.CartItems) // Sepet ile ilişkili CartItem'ları yükler
                .ThenInclude(ci => ci.Product) // CartItem ile ilişkili Product'ları yükler
                .FirstOrDefaultAsync(c => c.UserID == userId && c.RecordStatus !=RecordStatus.Deleted);
            // Kullanıcıya ait aktif sepeti getir
        }
        public async Task ClearCartAsync(int cartId)
        {
            var cart = await _table.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.CartID == cartId);
            if (cart != null)
            {
                _context.CartItems.RemoveRange(cart.CartItems);
                await _context.SaveChangesAsync();
            }
        }

    }

}
