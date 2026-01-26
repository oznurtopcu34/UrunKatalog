using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;
using Onion.Domain.Repositories;

namespace Onion.Application.Services.OrderService
{
    public class OrderService:IOrderService
    {     

        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;

        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
        }


        //siparis olusturacak
        public async Task<int> CreateOrderAsync(int userId)
        {
            var userCart = await _cartRepository.GetCartByUserIdAsync(userId);

            if (userCart == null || userCart.CartItems == null || !userCart.CartItems.Any())
                return -1;

            var newOrder = new Order
            {
                UserID = userId,
                TotalPrice = userCart.CartItems.Sum(c => c.Price),
                OrderDate = DateTime.Now,
                OrderItems = userCart.CartItems.Select(c => new OrderItem
                {
                    ProductID = c.ProductID,
                    Quantity = c.Quantity,
                    Price = c.Price
                }).ToList()
            };

            await _orderRepository.AddAsync(newOrder);

            userCart.CartItems.Clear();
            await _cartRepository.UpdateAsync(userCart);

            return newOrder.OrderID;
        }

        public async Task<List<Order_DTO>> GetOrdersByUserIdAsync(int userId)
        {
            // Kullanıcının siparişlerini al
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);

            // DTO'ya dönüştür ve geri döndür
            return orders.Select(o => new Order_DTO
            {
                OrderID = o.OrderID,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice
            }).ToList();
        }

        public async Task<int> GetOrdersCountLastWeekAsync()
        {
            return await _orderRepository.GetOrdersCountLastWeekAsync();
        }



    }
}
