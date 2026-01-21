using Onion.Domain.Abstract;
using Onion.Domain.Enums;

namespace Onion.Domain.Models
{
    public class Category : IEntity
    {
        public int CategoryID { get; set; } 
        public string CategoryName { get; set; }

        //ilişkiler
        public ICollection<Product>? Products { get; set; }


        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; } // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; } // Silinme tarihi
        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord; // Kayıt durumu


    }
}
