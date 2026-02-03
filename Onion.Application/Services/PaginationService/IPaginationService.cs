using Onion.Application.Model.DTO_s;

namespace Onion.Application.Services.PaginationService
{
    /// <summary>
    /// Genel sayfalandırma servisi. Veri kaynağına bağlı değildir; items + totalCount + page + pageSize ile PagedResult üretir.
    /// Diğer servisler kendi "tümünü getir" metodlarının içinde bu metodu çağırır.
    /// </summary>
    public interface IPaginationService
    {
        PagedResult_DTO<T> CreatePagedResult<T>(List<T> items, int totalCount, int page, int pageSize);
    }
}
