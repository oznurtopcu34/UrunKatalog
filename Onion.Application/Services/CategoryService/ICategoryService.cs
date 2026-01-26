using Onion.Application.Model.DTO_s;

namespace Onion.Application.Services.CategoryServise
{
    public interface ICategoryService
    {
        Task<List<Category_DTO>> GetAllCategoriesAsync(); // Tüm kategorileri getirir
        Task<Category_DTO> GetCategoryByIdAsync(int id); // ID'ye göre kategori getirir
        Task<bool> AddCategoryAsync(Category_DTO category); // Yeni kategori ekler
        Task<bool> UpdateCategoryAsync(Category_DTO category); // Mevcut kategoriyi günceller
        Task<bool> DeleteCategoryAsync(int id); // ID'ye göre kategori siler
        Task<Category_DTO> GetCategoryByNameAsync(string categoryName); //kategori adına göre arama
    }
}
