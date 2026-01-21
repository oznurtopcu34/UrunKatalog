using Onion.Domain.Abstract;
using Onion.Domain.Enums;

namespace Onion.Domain.Models
{
    public  class News : IEntity
    {
        public int NewsID { get; set; }      // Birincil anahtar
        public string Title { get; set; }   // Haber başlığı
        public string Content { get; set; } // Haber içeriği
        public string? Image { get; set; }  //resim
    

        // Ortak kategori ilişkisi
        public int ContentCategoryID { get; set; }
        public ContentCategory? ContentCategory { get; set; }

        // IEntity'den gelen özellikler
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; }               // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; }               // Silinme tarihi
        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord;
    }
}
