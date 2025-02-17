using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;
using Onion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.BlogPostService
{
    public class BlogPostService:IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IContentCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public BlogPostService(IBlogPostRepository blogPostRepository, IMapper mapper, IContentCategoryRepository categoryRepository)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<BlogPost_DTO>> GetAllBlogPostsAsync()
        {
            var blogPosts = await _blogPostRepository.GetAllAsync();
            var categories = await _categoryRepository.GetAllAsync();

            return blogPosts.Select(post => new BlogPost_DTO
            {
                BlogPostID = post.BlogPostID,
                Title = post.Title,
                Content = post.Content,
                Image = post.Image,
                ContentCategoryID = post.ContentCategoryID,
                ContentCategoryName = categories.FirstOrDefault(c => c.ContentCategoryID == post.ContentCategoryID)?.ContentCategoryName
            }).ToList();
        }

        public async Task<BlogPostUpdate_DTO> GetBlogPostByIdAsync(int id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);
            return _mapper.Map<BlogPostUpdate_DTO>(blogPost);
        }

        public async Task<bool> AddBlogPostAsync(BlogPostAdd_DTO blogPost)
        {
            var blogPostEntity = _mapper.Map<BlogPost>(blogPost);
            return await _blogPostRepository.AddAsync(blogPostEntity) > 0;
        }

        public async Task<bool> UpdateBlogPostAsync(BlogPostUpdate_DTO blogPost)
        {
            var existingBlogPost = await _blogPostRepository.GetByIdAsync(blogPost.BlogPostID);
            if (existingBlogPost == null) return false;

            _mapper.Map(blogPost, existingBlogPost);
            await _blogPostRepository.UpdateAsync(existingBlogPost);
            return true;
        }

        public async Task<bool> DeleteBlogPostAsync(int id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);
            if (blogPost == null) return false;

            await _blogPostRepository.DeleteAsync(id);
            return true;
        }
    }
}
