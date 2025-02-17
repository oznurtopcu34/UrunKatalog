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
    public class ReturnItemRepository : BaseRepository<ReturnItem>, IReturnItemRepository
    {
        public ReturnItemRepository(ProductDbContext context) : base(context) { }
    }
    
}
