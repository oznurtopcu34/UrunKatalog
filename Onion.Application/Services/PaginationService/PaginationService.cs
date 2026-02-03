using Onion.Application.Model.DTO_s;

namespace Onion.Application.Services.PaginationService
{
    public class PaginationService : IPaginationService
    {
        public PagedResult_DTO<T> CreatePagedResult<T>(List<T> items, int totalCount, int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            return new PagedResult_DTO<T>
            {
                Items = items ?? new List<T>(),
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}
