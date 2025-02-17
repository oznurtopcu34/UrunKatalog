using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;
using Onion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.CategoryServise
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        // Tüm kategorileri getirir
        public async Task<List<Category_DTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<Category_DTO>>(categories);
        }

        // Belirli bir ID'ye sahip kategoriyi getirir
        public async Task<Category_DTO> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<Category_DTO>(category);
        }

        // Yeni kategori ekler
        public async Task<bool> AddCategoryAsync(Category_DTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            return await _categoryRepository.AddAsync(categoryEntity) > 0;
        }

        // Mevcut kategoriyi günceller
        public async Task<bool> UpdateCategoryAsync(Category_DTO category)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(category.CategoryID);
            if (existingCategory == null) return false;

            _mapper.Map(category, existingCategory); // DTO -> Mevcut Entity
            await _categoryRepository.UpdateAsync(existingCategory);
            return true;
        }

        // Belirli bir ID'ye sahip kategoriyi siler
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return false;

            await _categoryRepository.DeleteAsync(id);
            return true;
        }
        public async Task<Category_DTO> GetCategoryByNameAsync(string categoryName)
        {
            var category = await _categoryRepository.GetCategoryByNameAsync(categoryName);
            if (category == null)
                return null;

            return new Category_DTO
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName
            };
        }
    }
}
