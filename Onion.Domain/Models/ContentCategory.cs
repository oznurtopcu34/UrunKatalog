using Onion.Domain.Abstract;
using Onion.Domain.Enums;

namespace Onion.Domain.Models
{
    public class ContentCategory : IEntity
    {

        public int ContentCategoryID { get; set; } 
        public string ContentCategoryName { get; set; }           
      

        // İlişkiler
        public ICollection<BlogPost>? BlogPosts { get; set; } // Bu kategoriyle ilişkilendirilen bloglar
        public ICollection<News>? NewsArticles { get; set; } // Bu kategoriyle ilişkilendirilen haberler


        // IEntity'den gelen özellikler
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; }               // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; }               // Silinme tarihi
        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord;


    }
}
