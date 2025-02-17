using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.BlogPostService;
using Onion.Application.Services.ContentCategoryService;
using Onion.UIWebApp.Models;

namespace Onion.UIWebApp.Areas.ContentManagerPanel.Controllers
{  [Area("ContentManagerPanel")]
   [Authorize(Roles = "ContentManager")]
    public class BlogPostController : Controller
    {

        private readonly IBlogPostService _blogPostService;
        private readonly IContentCategoryService _contentCategoryService;
        private readonly IMapper _mapper;

        public BlogPostController(IBlogPostService blogPostService, IContentCategoryService contentCategoryService, IMapper mapper)
        {
            _blogPostService = blogPostService;
            _contentCategoryService = contentCategoryService;
            _mapper = mapper;
        }

        // Blog yazılarının listelendiği ana sayfa
        public async Task<IActionResult> Index()
        {
            var blogPosts = await _blogPostService.GetAllBlogPostsAsync();
            return View(blogPosts);
        }

        // Blog yazısı ekleme sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> AddBlogPost()
        {
            ViewBag.Categories = await GetCategoriesForDropdownAsync();
            return View();
        }

        // Blog yazısı ekleme işlemi (POST)
        [HttpPost]
        public async Task<IActionResult> AddBlogPost(BlogPost_VM blogPostVM)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;

                // Resim yükleme işlemi
                if (blogPostVM.Image != null && blogPostVM.Image.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(blogPostVM.Image.FileName);

                    string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                    Directory.CreateDirectory(rootPath);

                    string filePath = Path.Combine(rootPath, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await blogPostVM.Image.CopyToAsync(fs);
                    }
                }

                // DTO'ya dönüştür ve servis katmanına gönder
                var blogPostDTO = new BlogPostAdd_DTO
                {
                    Title = blogPostVM.Title,
                    Content = blogPostVM.Content,
                    ContentCategoryID = blogPostVM.ContentCategoryID,
                    Image = fileName
                };

                var result = await _blogPostService.AddBlogPostAsync(blogPostDTO);

                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Blog yazısı eklenirken bir hata oluştu.");
            }

            ViewBag.Categories = await GetCategoriesForDropdownAsync();
            return View(blogPostVM);
        }


        // BlogPost Güncelleme Sayfası
        [HttpGet]
        public async Task<IActionResult> UpdateBlogPost(int id)
        {
            var blogPost = await _blogPostService.GetBlogPostByIdAsync(id);
            if (blogPost == null) return NotFound();

            ViewBag.Categories = await GetCategoriesForDropdownAsync();

            // Elle ViewModel'e dönüştürme
            var blogPostVM = new BlogPostUpdate
            {
                BlogPostID = blogPost.BlogPostID,
                Title = blogPost.Title,
                Content = blogPost.Content,
                ContentCategoryID = blogPost.ContentCategoryID,
                Image = null // IFormFile olarak ayarlanır
            };

            return View(blogPostVM);
        }

        // BlogPost Güncelleme İşlemi 
        [HttpPost]
        public async Task<IActionResult> UpdateBlogPost(BlogPostUpdate blogPostVM)
        {
            if (ModelState.IsValid)
            {
                string fileName = blogPostVM.Image?.FileName;

                // Resim yükleme işlemi
                if (blogPostVM.Image != null && blogPostVM.Image.Length > 0)
                {
                    //Farklı dosya adı oluştur
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(blogPostVM.Image.FileName);

                    // Resmi wwwroot/Images dizinine kaydet
                    string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                    Directory.CreateDirectory(rootPath); // Klasör yoksa oluştur

                    string filePath = Path.Combine(rootPath, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await blogPostVM.Image.CopyToAsync(fs);
                    }
                }

                // DTO'ya dönüştür
                var blogPostDTO = new BlogPostUpdate_DTO
                {
                    BlogPostID = blogPostVM.BlogPostID,
                    Title = blogPostVM.Title,
                    Content = blogPostVM.Content,
                    ContentCategoryID = blogPostVM.ContentCategoryID,
                    Image = fileName // Yüklenen resmin adı DTO'ya atanır
                };

                var result = await _blogPostService.UpdateBlogPostAsync(blogPostDTO);

                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Blog yazısı güncellenirken bir hata oluştu.");
            }

            ViewBag.Categories = await GetCategoriesForDropdownAsync();
            return View(blogPostVM);
        }





        // Blog yazısı silme işlemi
        [HttpPost]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            var result = await _blogPostService.DeleteBlogPostAsync(id);

            if (result)
                return RedirectToAction("Index");

            return BadRequest("Blog yazısı silinemedi.");
        }

        // kategorileri getirir
        private async Task<SelectList> GetCategoriesForDropdownAsync()
        {
            var categories = await _contentCategoryService.GetAllCategoriesAsync();
            return new SelectList(categories, "ContentCategoryID", "ContentCategoryName");
        }
    }
}
