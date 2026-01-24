using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories
{
    public class ReturnItemRepository : BaseRepository<ReturnItem>, IReturnItemRepository
    {
        public ReturnItemRepository(ProductDbContext context) : base(context) { }
    }
    
}
