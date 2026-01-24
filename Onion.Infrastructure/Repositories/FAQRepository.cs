using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories
{
   public class FAQRepository : BaseRepository<FAQ>, IFAQRepository
    {
        public FAQRepository(ProductDbContext context) : base(context)
        {
        }
    }
}
