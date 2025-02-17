using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Services.OrderService;

namespace Onion.UIWebApp.Areas.ManagerPanel.Controllers
{    
    [Area("ManagerPanel")]
     
    [Authorize(Roles = "Manager")]
    public class WeeklyOrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public WeeklyOrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> WeeklyOrders() //haftalık sipariş sayısı görüntüleme
        {
            var ordersCount = await _orderService.GetOrdersCountLastWeekAsync();
            ViewBag.OrdersCount = ordersCount;
            return View();
        }
    }
}
