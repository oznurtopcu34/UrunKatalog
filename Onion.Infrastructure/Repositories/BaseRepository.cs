using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Onion.Domain.Abstract;
using Onion.Domain.Enums;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;
using System.Linq.Expressions;

namespace Onion.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly ProductDbContext _context;
        protected readonly DbSet<TEntity> _table;

        public BaseRepository(ProductDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }
        public async Task<int> AddAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.RecordStatus = RecordStatus.Updated;
            _table.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                entity.DeletedDate = DateTime.Now;
                entity.RecordStatus = RecordStatus.Deleted;
                _table.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

    

        public async Task<IEnumerable<TResult>> FilterAndIncludeAsync<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _table.AsNoTracking();

            if (where != null)
                query = query.Where(where);

            if (include != null)
                query = include(query);

            if (orderBy != null)
                return await orderBy(query).Select(select).ToListAsync();

            return await query.Select(select).ToListAsync();
        }
   
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool all = false)
        {
            if (!all)
                return await _table.Where(e => e.RecordStatus != RecordStatus.Deleted).ToListAsync();
            return await _table.ToListAsync();
        }

        public async Task<(IEnumerable<TEntity> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = _table
                .AsNoTracking()
                .Where(e => e.RecordStatus != RecordStatus.Deleted);

            var totalCount = await query.CountAsync(cancellationToken);

            var keyProperty = _context.Model.FindEntityType(typeof(TEntity))?.FindPrimaryKey()?.Properties?.FirstOrDefault()?.Name;
            IOrderedQueryable<TEntity> orderedQuery = keyProperty != null
                ? query.OrderBy(e => EF.Property<int>(e, keyProperty))
                : query.OrderBy(e => e.CreatedDate);

            var items = await orderedQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return (items, totalCount);
        }
    }
}
