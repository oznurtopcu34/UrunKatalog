using Onion.Domain.Abstract;
using Onion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Models
{
    public class BlogPost : IEntity
    {
        public int BlogPostID { get; set; }   // Birincil anahtar
        public string Title { get; set; }    // Blog başlığı
        public string Content { get; set; }  // Blog içeriği
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
