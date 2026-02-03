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

        public async Task<IActionResult> Index(int page = 1, int pageSize = 3)
        {
            var paged = await _productService.GetAllProductsAsync(page, pageSize);
            return View(paged);
        }
        public async Task<IActionResult> Catalog(int page = 1, int pageSize = 3)
        {
            var paged = await _productService.GetAllProductsAsync(page, pageSize);
            return View(paged);
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


     

        // ?ye giri? kontrol? ile sepete ?r?n ekleme
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
            await _cartService.AddToCartAsync(productId, userId, quantity); // Sepete ekle
            return RedirectToAction("ViewCart"); // Sepeti g?r?nt?leme sayfas?na y?nlendir
        }

        // Sepeti g?r?nt?leme
        [Authorize]
        public async Task<IActionResult> ViewCart()
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
            var cart = await _cartService.GetCartByUserIdAsync(userId); // Kullan?c?n?n sepetini al
            if (cart == null)
            {
                return View(new Cart_VM()); // Kullan?c?n?n sepeti bo?sa bo? bir model d?n
            }
            var totalPrice = await _cartService.GetCartTotalPriceAsync(userId); // Toplam fiyat? al

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

            return View(viewModel); // Sepet view'ine g?nder
        }

        // Sepetten ?r?n silme
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
            await _cartService.RemoveFromCartAsync(cartItemId, userId); // Sepetten ?r?n? sil
            return RedirectToAction("ViewCart"); // Sepeti yeniden g?r?nt?le
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
                TempData["Error"] = "Sepetiniz bo?.";
                return RedirectToAction("ViewCart");
            }

            // Stok kontrol? ve stok azaltma
            var purchaseResult = await _cartService.PurchaseCartAsync(userId);
            if (!purchaseResult)
            {
                TempData["Error"] = "Sat?n alma i?lemi ba?ar?s?z. ?r?n stoklar?n? kontrol edin.";
                return RedirectToAction("ViewCart");
            }

            TempData["Success"] = "Sat?n alma i?lemi ba?ar?yla tamamland?.";
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
