using Microsoft.EntityFrameworkCore;
using Onion.Domain.Enums;
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
    public class ComplaintRepository : BaseRepository<Complaint>, IComplaintRepository
    {
        public ComplaintRepository(ProductDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Complaint>> GetUserComplaintsAsync(int userId)
        {
            return await _table
                .Where(c => c.UserID == userId && c.RecordStatus != RecordStatus.Deleted)
                .Include(c => c.User) // Kullanıcı bilgilerini çek
                .AsSplitQuery() // Çift sorgu ile yükleme yap
                .ToListAsync();
        }
        public async Task<IEnumerable<Complaint>> GetAllAsync()
        {
            return await _table
                .Include(c => c.UserID) // Kullanıcı bilgilerini dahil et
                 .AsSplitQuery()
                .ToListAsync();
        }

    }
}
