using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.CategoryServise;

namespace Onion.UIWebApp.Areas.ManagerPanel.Controllers
{
    [Area("ManagerPanel")]
    [Authorize(Roles = "Manager")]
    public class CategoryController : Controller
    {
       
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category_DTO category)
        {
            if (ModelState.IsValid)
            {
                // Kategori ismi zaten var mı kontrol et
                var existingCategory = await _categoryService.GetCategoryByNameAsync(category.CategoryName);
                if (existingCategory != null)
                {
                    ModelState.AddModelError("CategoryName", "Bu kategori adı zaten mevcut.");
                    return View(category);
                }

                // Eğer kategori yoksa ekleme işlemini gerçekleştir
                var result = await _categoryService.AddCategoryAsync(category);
                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Kategori eklenirken bir hata oluştu.");
            }
            return View(category);
        }

    

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category_DTO category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.UpdateCategoryAsync(category);
                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Kategori güncellenirken bir hata oluştu.");
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (result)
                return RedirectToAction("Index");

            return BadRequest("Kategori silinemedi.");
        }
    }
}
