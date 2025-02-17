using Onion.Application.Model.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.NewsService
{
    public interface INewsService
    {
        Task<bool> AddNewsAsync(NewsAdd_DTO news); // Yeni haber ekleme
        Task<bool> UpdateNewsAsync(NewsUpdate_DTO news); // Haber güncelleme
        Task<bool> DeleteNewsAsync(int newsId); // Haber silme
        Task<NewsUpdate_DTO> GetNewsByIdAsync(int id); // Belirli bir haberi ID ile alma
        Task<List<News_DTO>> GetAllNewsAsync(); // Tüm haberleri listeleme
    }
}
