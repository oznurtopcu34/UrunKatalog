using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.ContentCategoryService;
using Onion.Application.Services.NewsService;
using Onion.UIWebApp.Models;

namespace Onion.UIWebApp.Areas.ContentManagerPanel.Controllers
{ 
    [Area("ContentManagerPanel")]
   [Authorize(Roles = "ContentManager")]
    public class NewsController : Controller
    {
      

        private readonly INewsService _newsService;
        private readonly IContentCategoryService _contentCategoryService;
        private readonly IMapper _mapper;

        public NewsController(INewsService newsService, IContentCategoryService contentCategoryService, IMapper mapper)
        {
            _newsService = newsService;
            _contentCategoryService = contentCategoryService;
            _mapper = mapper;
        }

        // Haberlerin listelendiği ana sayfa
        public async Task<IActionResult> Index()
        {
            var newsItems = await _newsService.GetAllNewsAsync();
            return View(newsItems);
        }

        // Haber ekleme sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> AddNews()
        {
            ViewBag.Categories = await GetCategoriesForDropdownAsync();
            return View();
        }

        // Haber ekleme işlemi (POST)
        [HttpPost]
        public async Task<IActionResult> AddNews(News_VM newsVM)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;

                // Resim yükleme işlemi
                if (newsVM.Image != null && newsVM.Image.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(newsVM.Image.FileName);

                    string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                    Directory.CreateDirectory(rootPath);

                    string filePath = Path.Combine(rootPath, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await newsVM.Image.CopyToAsync(fs);
                    }
                }

                // DTO'ya dönüştür ve servis katmanına gönder
                var newsDTO = new NewsAdd_DTO
                {
                    Title = newsVM.Title,
                    Content = newsVM.Content,
                    ContentCategoryID = newsVM.ContentCategoryID,
                    Image = fileName
                };

                var result = await _newsService.AddNewsAsync(newsDTO);

                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Haber eklenirken bir hata oluştu.");
            }

            ViewBag.Categories = await GetCategoriesForDropdownAsync();
            return View(newsVM);
        }

        // Haber Güncelleme Sayfası
        [HttpGet]
        public async Task<IActionResult> UpdateNews(int id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            if (news == null) return NotFound();

            ViewBag.Categories = await GetCategoriesForDropdownAsync();

            // Elle ViewModel'e dönüştürme
            var newsVM = new NewsUpdate_VM
            {
                NewsID = news.NewsID,
                Title = news.Title,
                Content = news.Content,
                ContentCategoryID = news.ContentCategoryID,
                Image = null // IFormFile olarak ayarlanır
            };

            return View(newsVM);
        }

        // Haber Güncelleme İşlemi 
        [HttpPost]
        public async Task<IActionResult> UpdateNews(NewsUpdate_VM newsVM)
        {
            if (ModelState.IsValid)
            {
                string fileName = newsVM.Image?.FileName;

                // Resim yükleme işlemi
                if (newsVM.Image != null && newsVM.Image.Length > 0)
                {
                    // farklı dosya adı oluştur
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(newsVM.Image.FileName);

                    // Resmi wwwroot/Images dizinine kaydet
                    string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                    Directory.CreateDirectory(rootPath); // Klasör yoksa oluştur

                    string filePath = Path.Combine(rootPath, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await newsVM.Image.CopyToAsync(fs);
                    }
                }

                // DTO'ya dönüştür
                var newsDTO = new NewsUpdate_DTO
                {
                    NewsID = newsVM.NewsID,
                    Title = newsVM.Title,
                    Content = newsVM.Content,
                    ContentCategoryID = newsVM.ContentCategoryID,
                    Image = fileName // Yüklenen resmin adı DTO'ya atanır
                };

                var result = await _newsService.UpdateNewsAsync(newsDTO);

                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Haber güncellenirken bir hata oluştu.");
            }

            ViewBag.Categories = await GetCategoriesForDropdownAsync();
            return View(newsVM);
        }

        // Haber silme işlemi
        [HttpPost]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var result = await _newsService.DeleteNewsAsync(id);

            if (result)
                return RedirectToAction("Index");

            return BadRequest("Haber silinemedi.");
        }

        // kategorileri getirir
        private async Task<SelectList> GetCategoriesForDropdownAsync()
        {
            var categories = await _contentCategoryService.GetAllCategoriesAsync();
            return new SelectList(categories, "ContentCategoryID", "ContentCategoryName");
        }
    }
}
