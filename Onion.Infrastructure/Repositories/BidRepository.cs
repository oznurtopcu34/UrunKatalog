using Microsoft.EntityFrameworkCore;
using Onion.Domain.Enums;
using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories
{
    public class BidRepository : BaseRepository<Bid>, IBidRepository
    {
        public BidRepository(ProductDbContext context) : base(context)
        {
        }
        public async Task<Bid> GetByIdAsync(int id)
        {
            return await _table.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<IEnumerable<Bid>> GetPendingBidsAsync()
        {
            return await _table.Where(b => b.Status == ReturnStatus.Pending).ToListAsync();
        }

        public async Task ApproveBidAsync(int id)
        {
            var bid = await GetByIdAsync(id);
            if (bid != null)
            {
                bid.Status = ReturnStatus.Approved;
                bid.CreatedDate = System.DateTime.Now;
                await UpdateAsync(bid);
            }
        }

        public async Task RejectBidAsync(int id)
        {
            var bid = await GetByIdAsync(id);
            if (bid != null)
            {
                bid.Status = ReturnStatus.Rejected;
                bid.UpdatedDate = System.DateTime.Now;
                await UpdateAsync(bid);
            }
        }
    }
}
