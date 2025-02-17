using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Onion.Application.Services.CartServices;
using Onion.Application.Services.CategoryServise;
using Onion.Application.Services.ProductServices;
using Onion.Application.Services.ReturnServices;
using Onion.UIWebApp.Models;
using System.Diagnostics;

namespace Onion.UIWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductService _productService;
        private readonly IReturnService _returnService;
        private readonly ICategoryService _categoryService;
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public HomeController(IProductService productService, IMapper mapper,ICategoryService categoryService , ICartService cartService, IReturnService returnService)
        {
            _productService = productService;
            _returnService = returnService;
            _cartService=cartService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task <IActionResult> Index()
        {
            Thread.Sleep(10000);
            
            SentrySdk.CaptureMessage("Hello Sentry");
            var products=await _productService.GetAllProductsAsync();
            return View(products);
        }
        public async Task<IActionResult> Catalog()
        {
            // Tüm ürünleri ve kategorileri içeren DTO'yu alýyoruz
            var products = await _productService.GetAllProductsAsync();
            return View(products);  // View'a gönderiyoruz
        }
        public async Task<IActionResult> ProductDetail(int id)
        {
          
            var productdetail = await _productService.GetProductByIdAsync(id);
              ViewBag.Categories = await GetCategoriesForDropdownAsync();
            return View(productdetail);
        }

        private async Task<List<SelectListItem>> GetCategoriesForDropdownAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return categories.Select(c => new SelectListItem
            {
                Value = c.CategoryID.ToString(),
                Text = c.CategoryName
            }).ToList();
        }


     

        // Üye giriþ kontrolü ile sepete ürün ekleme
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
            await _cartService.AddToCartAsync(productId, userId, quantity); // Sepete ekle
            return RedirectToAction("ViewCart"); // Sepeti görüntüleme sayfasýna yönlendir
        }

        // Sepeti görüntüleme
        [Authorize]
        public async Task<IActionResult> ViewCart()
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
            var cart = await _cartService.GetCartByUserIdAsync(userId); // Kullanýcýnýn sepetini al
            if (cart == null)
            {
                return View(new Cart_VM()); // Kullanýcýnýn sepeti boþsa boþ bir model dön
            }
            var totalPrice = await _cartService.GetCartTotalPriceAsync(userId); // Toplam fiyatý al

            var viewModel = new Cart_VM
            {
                CartItems = cart.CartItems?.Select(ci => new CartItem_VM
                {
                    CartItemID = ci.CartItemID,
                    ProductName = ci.Product.ProductName,
                    Quantity = ci.Quantity,
                    Price = ci.Price
                }).ToList(),
                TotalPrice = totalPrice
            };

            return View(viewModel); // Sepet view'ine gönder
        }

        // Sepetten ürün silme
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
            await _cartService.RemoveFromCartAsync(cartItemId, userId); // Sepetten ürünü sil
            return RedirectToAction("ViewCart"); // Sepeti yeniden görüntüle
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PurchaseCart()
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

            // Sepeti al
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            if (cart == null || !cart.CartItems.Any())
            {
                TempData["Error"] = "Sepetiniz boþ.";
                return RedirectToAction("ViewCart");
            }

            // Stok kontrolü ve stok azaltma
            var purchaseResult = await _cartService.PurchaseCartAsync(userId);
            if (!purchaseResult)
            {
                TempData["Error"] = "Satýn alma iþlemi baþarýsýz. Ürün stoklarýný kontrol edin.";
                return RedirectToAction("ViewCart");
            }

            TempData["Success"] = "Satýn alma iþlemi baþarýyla tamamlandý.";
            return RedirectToAction("ViewCart");
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
