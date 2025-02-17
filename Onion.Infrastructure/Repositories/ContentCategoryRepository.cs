using Microsoft.EntityFrameworkCore;
using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Infrastructure.Repositories
{
    public class ContentCategoryRepository : BaseRepository<ContentCategory>, IContentCategoryRepository
    {
        public ContentCategoryRepository(ProductDbContext context) : base(context)
        {
        }
        public async Task<ContentCategory> GetContentCategoryByNameAsync(string categoryName)
        {
            return await _context.ContentCategories
                                 .FirstOrDefaultAsync(c => c.ContentCategoryName.ToLower() == categoryName.ToLower());
        }
    }
}
