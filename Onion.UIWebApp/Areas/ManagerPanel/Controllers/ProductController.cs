using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.CategoryServise;
using Onion.Application.Services.ProductServices;
using Onion.UIWebApp.Models;

namespace Onion.UIWebApp.Areas.ManagerPanel.Controllers
{
    [Area("ManagerPanel")]
    [Authorize(Roles = "Manager")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
             ViewBag.Categories = await GetCategoriesForDropdownAsync();
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        // Ürün Ekleme Sayfası 
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            ViewBag.Categories = await GetCategoriesForDropdownAsync();
            return View();
        }

        // Ürün Ekleme İşlemi 
        [HttpPost]
     
        public async Task<IActionResult> AddProduct(ProductAdd_VM productVM)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;

                // Resim yükleme işlemi
                if (productVM.Image != null && productVM.Image.Length > 0)
                {
                   
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(productVM.Image.FileName);

                    // Resmi wwwroot/Images dizinine kaydet
                    string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                    Directory.CreateDirectory(rootPath); // Klasör yoksa oluştur

                    string filePath = Path.Combine(rootPath, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await productVM.Image.CopyToAsync(fs);
                    }
                }

                // DTO'ya dönüştür
                var productDTO = new ProductAdd_DTO
                {
                    ProductName = productVM.ProductName,
                    Description = productVM.Description,
                    Price = productVM.Price,
                    Stock = productVM.Stock,
                    CategoryID = productVM.CategoryID,
                    Image = fileName 
                };

                var result = await _productService.AddProductAsync(productDTO);

                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Ürün eklenirken bir hata oluştu.");
            }

            ViewBag.Categories = await GetCategoriesForDropdownAsync();
            return View(productVM);
        }

        // Ürün Güncelleme Sayfası
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            ViewBag.Categories = await GetCategoriesForDropdownAsync();

            // Elle ViewModel'e dönüştürme
            var productVM = new ProductUpdate_VM
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryID = product.CategoryID,
                Image = null // IFormFile olarak ayarlanır
            };

            return View(productVM);
        }

        // Ürün Güncelleme İşlemi 
        [HttpPost]
  
        public async Task<IActionResult> UpdateProduct(ProductUpdate_VM productVM)
        {
            if (ModelState.IsValid)
            {
                string fileName = productVM.Image?.FileName;

                // Resim yükleme işlemi
                if (productVM.Image != null && productVM.Image.Length > 0)
                {
                    // farklı dosya adı oluştur
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(productVM.Image.FileName);

                    // Resmi wwwroot/Images dizinine kaydet
                    string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                    Directory.CreateDirectory(rootPath); // Klasör yoksa oluştur

                    string filePath = Path.Combine(rootPath, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await productVM.Image.CopyToAsync(fs);
                    }
                }

                // DTO'ya dönüştür
                var productDTO = new ProductUpdate_DTO
                {
                    ProductID = productVM.ProductID,
                    ProductName = productVM.ProductName,
                    Description = productVM.Description,
                    Price = productVM.Price,
                    Stock = productVM.Stock,
                    CategoryID = productVM.CategoryID,
                    Image = fileName // Yüklenen resmin adı DTO'ya atanır
                };

                var result = await _productService.UpdateProductAsync(productDTO);

                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Ürün güncellenirken bir hata oluştu.");
            }

            ViewBag.Categories = await GetCategoriesForDropdownAsync();
            return View(productVM);
        }

        // Ürün Silme İşlemi
        [HttpPost]
     
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (result)
                return RedirectToAction("Index");

            return BadRequest("Ürün silinemedi.");
        }

        
        private async Task<SelectList> GetCategoriesForDropdownAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return new SelectList(categories, "CategoryID", "CategoryName");
        }




    }
}
