using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;
using Onion.Domain.Repositories;

namespace Onion.Application.Services.ContentCategoryService
{
    public class ContentCategoryService :IContentCategoryService
    {
        private readonly IContentCategoryRepository _contentCategoryRepository;
        private readonly IMapper _mapper;

        public ContentCategoryService(IContentCategoryRepository contentCategoryRepository, IMapper mapper)
        {
            _contentCategoryRepository = contentCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ContentCategory_DTO>> GetAllCategoriesAsync()
        {
            var categories = await _contentCategoryRepository.GetAllAsync();
            return _mapper.Map<List<ContentCategory_DTO>>(categories);
        }

        public async Task<ContentCategory_DTO> GetCategoryByIdAsync(int id)
        {
            var category = await _contentCategoryRepository.GetByIdAsync(id);
            return _mapper.Map<ContentCategory_DTO>(category);
        }

        public async Task<bool> AddCategoryAsync(ContentCategory_DTO category)
        {
            var categoryEntity = _mapper.Map<ContentCategory>(category);
            return await _contentCategoryRepository.AddAsync(categoryEntity) > 0;
        }

        public async Task<bool> UpdateCategoryAsync(ContentCategory_DTO category)
        {
            var existingCategory = await _contentCategoryRepository.GetByIdAsync(category.ContentCategoryID);
            if (existingCategory == null) return false;

            _mapper.Map(category, existingCategory);
            await _contentCategoryRepository.UpdateAsync(existingCategory);
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _contentCategoryRepository.GetByIdAsync(id);
            if (category == null) return false;

            await _contentCategoryRepository.DeleteAsync(id);
            return true;
        }


        public async Task<ContentCategory_DTO> GetContentCategoryByNameAsync(string categoryName)
        {
            var category = await _contentCategoryRepository.GetContentCategoryByNameAsync(categoryName);
            if (category == null)
                return null;

            return new ContentCategory_DTO
            {
                ContentCategoryID = category.ContentCategoryID,
                ContentCategoryName = category.ContentCategoryName,
            };
        }

    }
}
