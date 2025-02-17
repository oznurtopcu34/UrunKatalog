using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.CartServices
{
    public interface ICartService
    {
        Task<bool> AddToCartAsync(int productId, int userId, int quantity); // Sepete ürün ekleme
        Task<bool> RemoveFromCartAsync(int cartItemId, int userId); // Sepetten ürün silme
        Task<decimal> GetCartTotalPriceAsync(int userId); // Sepetin toplam fiyatını hesaplama
        Task<Cart> GetCartByUserIdAsync(int userId); // Kullanıcıya ait sepeti al
        Task<bool> PurchaseCartAsync(int userId); //Kullanıcının sepetindeki ürünleri satın almasını sağlar.
    }
}
