using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Onion.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id); // ID ile bir kaydı asenkron getirir
        Task<IEnumerable<TEntity>> GetAllAsync(bool all = false); // Tüm kayıtları asenkron listeler
        /// <summary>
        /// Sayfalı liste (silinmemiş kayıtlar). Product, Category vb. tüm entity'ler için kullanılabilir.
        /// </summary>
        Task<(IEnumerable<TEntity> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default);
        Task<int> AddAsync(TEntity entity); // Yeni bir kaydı asenkron ekler
        Task UpdateAsync(TEntity entity); // Mevcut bir kaydı asenkron günceller
        Task DeleteAsync(int id); // ID ile bir kaydı asenkron siler
        Task<IEnumerable<TResult>> FilterAndIncludeAsync<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);  // Filtrele ve Birleştir

    }
}
