using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.CartServices
{
    public class CartService:ICartService
    {

        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        // Kullanıcının sepetine ürün eklemesi
        public async Task<bool> AddToCartAsync(int productId, int userId, int quantity)
        {
            var existingCart = await _cartRepository.GetCartByUserIdAsync(userId);

            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserID = userId,
                    CartItems = new List<CartItem>
                    {
                        new CartItem
                        {
                            ProductID = productId,
                            Quantity = quantity,
                            Price = (await _productRepository.GetByIdAsync(productId)).Price * quantity
                        }
                    }
                };
                await _cartRepository.AddAsync(newCart);
            }
            else
            {
                var existingCartItem = existingCart.CartItems?.FirstOrDefault(ci => ci.ProductID == productId);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += quantity;
                    existingCartItem.Price += (await _productRepository.GetByIdAsync(productId)).Price * quantity;
                }
                else
                {
                    existingCart.CartItems.Add(new CartItem
                    {
                        ProductID = productId,
                        Quantity = quantity,
                        Price = (await _productRepository.GetByIdAsync(productId)).Price * quantity
                    });
                }
                await _cartRepository.UpdateAsync(existingCart);
            }
            return true;
        }

        // Kullanıcının sepetinden ürün çıkarma
        public async Task<bool> RemoveFromCartAsync(int cartItemId, int userId)
        {
            var userCart = await _cartRepository.GetCartByUserIdAsync(userId);

            if (userCart == null || userCart.CartItems == null)
                return false;

            var cartItem = userCart.CartItems.FirstOrDefault(c => c.CartItemID == cartItemId);

            if (cartItem == null)
                return false;

            userCart.CartItems.Remove(cartItem);
            await _cartRepository.UpdateAsync(userCart);
            return true;
        }


        // Kullanıcının sepetindeki toplam fiyatı 
        public async Task<decimal> GetCartTotalPriceAsync(int userId)
        {
            var userCart = await _cartRepository.GetCartByUserIdAsync(userId);

            if (userCart == null || userCart.CartItems == null || !userCart.CartItems.Any())
                return 0;

            return userCart.CartItems.Sum(c => c.Price);
        }

        // Kullanıcının sepetini almak için 
        public async Task<Cart> GetCartByUserIdAsync(int userId)
        {
            return await _cartRepository.GetCartByUserIdAsync(userId); // Repository'den kullanıcı sepetini al
        }
        // Kullanıcının sepetini satın alma işlemi
        public async Task<bool> PurchaseCartAsync(int userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null || !cart.CartItems.Any())
                return false;

            foreach (var item in cart.CartItems)
            {
                // Ürün stok kontrolü
                if (item.Product.Stock < item.Quantity)
                    return false;

                // Stok azaltma
                item.Product.Stock -= item.Quantity;
            }

            // Sipariş oluşturma
            var order = new Order
            {
                UserID = userId,
                OrderDate = DateTime.Now,
                TotalPrice = cart.CartItems.Sum(c => c.Price * c.Quantity),
                OrderItems = cart.CartItems.Select(c => new OrderItem
                {
                    ProductID = c.ProductID,
                    Quantity = c.Quantity,
                    Price = c.Price
                }).ToList()
            };

            // Veritabanında güncellemeler
            await _orderRepository.AddAsync(order);
            await _cartRepository.ClearCartAsync(cart.CartID); // Sepeti temizle

            return true;
        }

    }
}
