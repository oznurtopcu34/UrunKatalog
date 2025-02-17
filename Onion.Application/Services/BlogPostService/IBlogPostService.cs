using Onion.Application.Model.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.BlogPostService
{
    public interface IBlogPostService
    {
        Task<List<BlogPost_DTO>> GetAllBlogPostsAsync(); //Tüm blog gönderilerini getirir.
        Task<BlogPostUpdate_DTO> GetBlogPostByIdAsync(int id); // Belirtilen ID'ye sahip blog gönderisini getirir.
        Task<bool> AddBlogPostAsync(BlogPostAdd_DTO blogPost); // Yeni bir blog gönderisi ekler.
        Task<bool> UpdateBlogPostAsync(BlogPostUpdate_DTO blogPost); // Mevcut bir blog gönderisini günceller
        Task<bool> DeleteBlogPostAsync(int id);// Belirtilen ID'ye sahip blog gönderisini siler.
    }
}
