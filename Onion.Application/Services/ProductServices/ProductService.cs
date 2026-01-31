using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;
using Onion.Domain.Repositories;

namespace Onion.Application.Services.ProductServices
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        // Yeni bir ürün ekler
        public async Task<bool> AddProductAsync(ProductAdd_DTO product)
        {
            var productEntity = _mapper.Map<Product>(product); 
            return await _productRepository.AddAsync(productEntity) > 0;
        }

        // Mevcut bir ürünü günceller
        public async Task<bool> UpdateProductAsync(ProductUpdate_DTO product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(product.ProductID);
            if (existingProduct == null) return false;

            _mapper.Map(product, existingProduct); // DTO -> Mevcut Entity güncellemesi
            await _productRepository.UpdateAsync(existingProduct);

            return true;
        }

        // Belirtilen ID'ye sahip bir ürünü siler
        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return false;

            await _productRepository.DeleteAsync(productId);
            return true;
        }

        // Belirtilen ID'ye sahip bir ürünün bilgilerini getirir
        public async Task<ProductUpdate_DTO> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductUpdate_DTO>(product); // Entity -> DTO dönüşümü
        }

        // Tüm ürünlerin listesini getirir
        public async Task<List<ProductUpdate_DTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var categories = await _categoryRepository.GetAllAsync(); // Kategorileri al

            var productDTOs = products.Select(p => new ProductUpdate_DTO
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                CategoryID = p.CategoryID,
                CategoryName = categories.FirstOrDefault(c => c.CategoryID == p.CategoryID)?.CategoryName, // Kategori adı
                Image = p.Image // Resim ekleniyor
            }).ToList();

            return productDTOs;

        }
    }
}
