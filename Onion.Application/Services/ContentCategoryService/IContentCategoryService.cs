using Onion.Application.Model.DTO_s;

namespace Onion.Application.Services.ContentCategoryService
{
    public interface IContentCategoryService
    {
        Task<List<ContentCategory_DTO>> GetAllCategoriesAsync();// Tüm kategorileri getirir
        Task<ContentCategory_DTO> GetCategoryByIdAsync(int id);// ID'ye göre kategori getirir
        Task<bool> AddCategoryAsync(ContentCategory_DTO category);// Yeni kategori ekler
        Task<bool> UpdateCategoryAsync(ContentCategory_DTO category);// Mevcut kategoriyi günceller
        Task<bool> DeleteCategoryAsync(int id);// ID'ye göre kategori siler
        Task<ContentCategory_DTO> GetContentCategoryByNameAsync(string categoryName);//kategori adına göre arama
    }
}
