using Onion.Domain.Abstract;
using Onion.Domain.Enums;

namespace Onion.Domain.Models
{
    public class Product : IEntity
    {
        public int ProductID { get; set; } 
        public string ProductName { get; set; } 
        public string Description { get; set; } // acıklama
        public decimal Price { get; set; }  //fiyat
        public int Stock { get; set; }  //stok  
        public string? Image { get; set; }  //resim

        //ilişkiler
        public int CategoryID { get; set; } 
        public Category? Category { get; set; }

        public ICollection<CartItem>? CartItems { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<ReturnItem>? ReturnItems { get; set; }
        public ICollection<Bid>? Bids {  get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; } // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; } // Silinme tarihi
        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord; // Kayıt durumu
    }
}
