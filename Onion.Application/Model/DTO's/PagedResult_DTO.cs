namespace Onion.Application.Model.DTO_s
{
    /// <summary>
    /// Sayfalı liste sonucu. Ürün, kategori vb. tüm listelerde kullanılabilir.
    /// </summary>
    public class PagedResult_DTO<T>
    {
        public List<T> Items { get; set; } = new();           // Bu sayfadaki kayıt listesi
        public int TotalCount { get; set; }                   // Toplam kayıt sayısı
        public int Page { get; set; }                         // Mevcut sayfa numarası
        public int PageSize { get; set; }                     // Sayfa başına kayıt sayısı
        public int TotalPages => PageSize > 0 ? (int)Math.Ceiling(TotalCount / (double)PageSize) : 0;  // Toplam sayfa sayısı
        public bool HasPreviousPage => Page > 1;              // Önceki sayfa var mı
        public bool HasNextPage => Page < TotalPages;         // Sonraki sayfa var mı
    }
}
