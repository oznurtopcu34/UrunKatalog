using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.PaginationService;
using Onion.Domain.Models;
using Onion.Domain.Repositories;

namespace Onion.Application.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IPaginationService _paginationService;

        public ProductService(
            IProductRepository productRepository,
            IMapper mapper,
            ICategoryRepository categoryRepository,
            IPaginationService paginationService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _paginationService = paginationService;
        }

        public async Task<bool> AddProductAsync(ProductAdd_DTO product)
        {
            var entity = _mapper.Map<Product>(product);
            return await _productRepository.AddAsync(entity) > 0;
        }

        public async Task<bool> UpdateProductAsync(ProductUpdate_DTO product)
        {
            var existing = await _productRepository.GetByIdAsync(product.ProductID);
            if (existing == null) return false;
            _mapper.Map(product, existing);
            await _productRepository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return false;
            await _productRepository.DeleteAsync(productId);
            return true;
        }

        public async Task<ProductUpdate_DTO> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductUpdate_DTO>(product);
        }

        public async Task<List<ProductUpdate_DTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var categories = await _categoryRepository.GetAllAsync();
            return MapToProductDtos(products, categories);
        }

        public async Task<PagedResult_DTO<ProductUpdate_DTO>> GetAllProductsAsync(int page, int pageSize, CancellationToken cancellationToken = default)
        {
            var (items, totalCount) = await _productRepository.GetPagedAsync(page, pageSize, cancellationToken);
            var categories = await _categoryRepository.GetAllAsync();
            var dtos = MapToProductDtos(items, categories);
            return _paginationService.CreatePagedResult(dtos, totalCount, page, pageSize);
        }

        private static List<ProductUpdate_DTO> MapToProductDtos(IEnumerable<Product> products, IEnumerable<Category> categories)
        {
            var categoryList = categories.ToList();
            return products.Select(p => new ProductUpdate_DTO
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                CategoryID = p.CategoryID,
                CategoryName = categoryList.FirstOrDefault(c => c.CategoryID == p.CategoryID)?.CategoryName,
                Image = p.Image
            }).ToList();
        }
    }
}
