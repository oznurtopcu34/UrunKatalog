﻿using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Infrastructure.Repositories
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        public NewsRepository(ProductDbContext context) : base(context)
        {
        }
    }
}
