using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;
using Onion.Domain.Repositories;

namespace Onion.Application.Services.NewsService
{
    public class NewsService :INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IContentCategoryRepository _contentCategoryRepository;
        private readonly IMapper _mapper;

        public NewsService(INewsRepository newsRepository, IMapper mapper, IContentCategoryRepository contentCategoryRepository)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
            _contentCategoryRepository = contentCategoryRepository;
        }

        // Yeni haber ekleme
        public async Task<bool> AddNewsAsync(NewsAdd_DTO news)
        {
            var newsEntity = _mapper.Map<News>(news);
            return await _newsRepository.AddAsync(newsEntity) > 0;
        }

        // Haber güncelleme
        public async Task<bool> UpdateNewsAsync(NewsUpdate_DTO news)
        {
            var existingNews = await _newsRepository.GetByIdAsync(news.NewsID);
            if (existingNews == null) return false;

            _mapper.Map(news, existingNews); // DTO -> Entity
            await _newsRepository.UpdateAsync(existingNews);

            return true;
        }

        // Haber silme
        public async Task<bool> DeleteNewsAsync(int newsId)
        {
            var news = await _newsRepository.GetByIdAsync(newsId);
            if (news == null) return false;

            await _newsRepository.DeleteAsync(newsId);
            return true;
        }

        // ID ile haber alma
        public async Task<NewsUpdate_DTO> GetNewsByIdAsync(int id)
        {
            var news = await _newsRepository.GetByIdAsync(id);
            return _mapper.Map<NewsUpdate_DTO>(news);
        }

        // Tüm haberleri listeleme
        public async Task<List<News_DTO>> GetAllNewsAsync()
        {
            var newsList = await _newsRepository.GetAllAsync();
            var categories = await _contentCategoryRepository.GetAllAsync();

            return newsList.Select(news => new News_DTO
            {
                NewsID = news.NewsID,
                Title = news.Title,
                Content = news.Content,
                Image = news.Image,
                ContentCategoryID = news.ContentCategoryID,
                ContentCategoryName = categories.FirstOrDefault(c => c.ContentCategoryID == news.ContentCategoryID)?.ContentCategoryName
            }).ToList();
        }
    }
}
