using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context) { }
    }
   
}
