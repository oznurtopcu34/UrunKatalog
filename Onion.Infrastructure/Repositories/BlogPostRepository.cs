using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(ProductDbContext context) : base(context)
        {
        }
    }
}
