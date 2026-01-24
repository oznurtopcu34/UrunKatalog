using Microsoft.EntityFrameworkCore;
using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories
{
    public class ReturnRepository : BaseRepository<Return>, IReturnRepository
    {
        public ReturnRepository(ProductDbContext context) : base(context) { }
  
        public async Task<List<Return>> GetAllWithDetailsAsync()
        {
            return await _context.Returns
                .Include(r => r.User) // Kullanıcı bilgisi
                .Include(r => r.ReturnItems) // İade edilen ürünler
                    .ThenInclude(ri => ri.Product) // Ürün bilgisi
                .Include(r => r.Order) // Sipariş bilgisi
                .ToListAsync();
        }


    }
}
