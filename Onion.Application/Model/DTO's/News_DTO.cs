namespace Onion.Application.Model.DTO_s
{
    public class News_DTO
    {
        public int NewsID { get; set; } // Haber ID
        public string Title { get; set; } // Haber başlığı
        public string Content { get; set; } // Haber içeriği
        public string? Image { get; set; } // Haber resmi
        public int ContentCategoryID { get; set; } // Kategori ID
        public string? ContentCategoryName { get; set; } // Kategori adı
    }
}
