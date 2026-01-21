using Onion.Domain.Abstract;
using Onion.Domain.Enums;

namespace Onion.Domain.Models
{
    public class Cart : IEntity   //Sepet
    {
        public int CartID { get; set; }

        //ilişkiler
        public int UserID { get; set; } 
        public User? User { get; set; } 
        public ICollection<CartItem>? CartItems { get; set; }
        public ICollection<Order>? Orders { get; set; } // Sepetin siparişleri

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; } // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; } // Silinme tarihi
        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord; // Kayıt durumu
    }
}
