using Onion.Application.Model.DTO_s;

namespace Onion.Application.Services.ProductServices
{
    public interface IProductService
    {
        // Yeni bir ürün ekler.
        Task<bool> AddProductAsync(ProductAdd_DTO product);

        // Mevcut bir ürünü günceller.
        Task<bool> UpdateProductAsync(ProductUpdate_DTO product);

        // Belirtilen ID'ye sahip bir ürünü siler.
        Task<bool> DeleteProductAsync(int productId);

        // Belirtilen ID'ye sahip bir ürünün bilgilerini getirir.
        Task<ProductUpdate_DTO> GetProductByIdAsync(int id);

        /// <summary>
        /// Tüm ürünler (sayfalandırma yok). Panel vb. için.
        /// </summary>
        Task<List<ProductUpdate_DTO>> GetAllProductsAsync();

        /// <summary>
        /// Tüm ürünler sayfalı. İçeride IPaginationService.CreatePagedResult çağrılır.
        /// </summary>
        Task<PagedResult_DTO<ProductUpdate_DTO>> GetAllProductsAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    }
}
