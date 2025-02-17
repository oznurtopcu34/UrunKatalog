using Microsoft.AspNetCore.Mvc;
using Onion.Application.Services.BlogPostService;

namespace Onion.UIWebApp.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public async Task<IActionResult> Index()
        {
            var blogPosts = await _blogPostService.GetAllBlogPostsAsync();
            return View(blogPosts);
        }

    }
}
