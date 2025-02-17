namespace Onion.UIWebApp.Models
{
    public class Cart_VM
    {
        public List<CartItem_VM>? CartItems { get; set; } = new List<CartItem_VM>();
        public decimal TotalPrice { get; set; } // Sepetin toplam fiyatı
    }
}
