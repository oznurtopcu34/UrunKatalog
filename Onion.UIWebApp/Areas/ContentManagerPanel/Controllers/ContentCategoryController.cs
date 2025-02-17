using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;

using Onion.Application.Services.ContentCategoryService;

namespace Onion.UIWebApp.Areas.ContentManagerPanel.Controllers
{
    [Area("ContentManagerPanel")]
  [Authorize(Roles = "ContentManager")]
    public class ContentCategoryController : Controller
    {

        private readonly IContentCategoryService _contentCategoryService;
        private readonly IMapper _mapper;

        public ContentCategoryController(IContentCategoryService contentCategoryService, IMapper mapper)
        {
            _contentCategoryService = contentCategoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _contentCategoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]


        public async Task<IActionResult> AddCategory(ContentCategory_DTO category)
        {
            if (ModelState.IsValid)
            {
                // Kategori ismi zaten var mı kontrol et
                var existingCategory = await _contentCategoryService.GetContentCategoryByNameAsync(category.ContentCategoryName);
                if (existingCategory != null)
                {
                    ModelState.AddModelError("ContentCategoryName", "Bu kategori adı zaten mevcut.");
                    return View(category);
                }

                // Eğer kategori yoksa ekleme işlemini gerçekleştir
                var result = await _contentCategoryService.AddCategoryAsync(category);
                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Kategori eklenirken bir hata oluştu.");
            }
            return View(category);
        }


        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _contentCategoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(ContentCategory_DTO category)
        {
            if (ModelState.IsValid)
            {
                var result = await _contentCategoryService.UpdateCategoryAsync(category);
                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Kategori güncellenirken bir hata oluştu.");
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _contentCategoryService.DeleteCategoryAsync(id);
            if (result)
                return RedirectToAction("Index");

            return BadRequest("Kategori silinemedi.");
        }
    }
}
