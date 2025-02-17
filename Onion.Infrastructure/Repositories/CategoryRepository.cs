﻿using Microsoft.EntityFrameworkCore;
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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductDbContext context) : base(context) { }
        public async Task<Category> GetCategoryByNameAsync(string categoryName)
        {
            return await _context.Categories
                                 .FirstOrDefaultAsync(c => c.CategoryName.ToLower() == categoryName.ToLower());
        }
    }
   
}
