using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Repositories
{
    public interface IContentCategoryRepository:IBaseRepository<ContentCategory>
    {
        Task<ContentCategory> GetContentCategoryByNameAsync(string categoryName);//kategori adına göre arama
    }
}
