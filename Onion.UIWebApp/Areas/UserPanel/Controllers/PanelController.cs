using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Services.OrderService;
using Onion.Application.Services.ReturnServices;
using Onion.Application.Services.UserServices;

namespace Onion.UIWebApp.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize(Roles = "User")]
    public class PanelController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IReturnService _returnService;
        private readonly IUserService _userService;
        public PanelController(IOrderService orderService, IReturnService returnService , IUserService userService)
        {
            _orderService = orderService;
            _userService= userService;
            _returnService = returnService;
        }
        public IActionResult RedirectToCart()
        {
            return RedirectToAction("ViewCart", "Home", new { area = "" }); // HomeController içindeki ViewCart aksiyonuna yönlendir
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> MyOrders()
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return View(orders);
        }


        [HttpPost]
        public async Task<IActionResult> RequestReturn(int orderId, string reason)
        {
            // Kullanıcı kimliğini güvenli bir şekilde al
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var userId))
            {
                TempData["Error"] = "Kullanıcı doğrulama hatası. Lütfen oturumunuzu kontrol edin.";
                return RedirectToAction("MyOrders");
            }

            // İade talebi oluşturmak için servisi çağır
            var result = await _returnService.RequestReturnAsync(orderId, userId, reason);

            // Sonuca göre kullanıcıya mesaj göster
            if (result)
            {
                TempData["Success"] = "İade talebiniz başarıyla oluşturuldu.";
            }
            else
            {
                TempData["Error"] = "İade talebi oluşturulamadı. Sipariş numaranızın ve iade nedeninizin geçerli olduğundan emin olun.";
            }

            return RedirectToAction("MyOrders");
        }




    }
}
