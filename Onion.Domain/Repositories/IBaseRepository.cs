using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id); // ID ile bir kaydı asenkron getirir
        Task<IEnumerable<TEntity>> GetAllAsync(bool all = false); // Tüm kayıtları asenkron listeler
        Task<int> AddAsync(TEntity entity); // Yeni bir kaydı asenkron ekler
        Task UpdateAsync(TEntity entity); // Mevcut bir kaydı asenkron günceller
        Task DeleteAsync(int id); // ID ile bir kaydı asenkron siler
        Task<IEnumerable<TResult>> FilterAndIncludeAsync<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);  // Filtrele ve Birleştir

    }
}
