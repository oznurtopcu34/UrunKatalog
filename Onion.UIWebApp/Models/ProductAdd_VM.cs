using System.ComponentModel.DataAnnotations;

namespace Onion.UIWebApp.Models
{
    public class ProductAdd_VM
    {
        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Ürün açıklaması zorunludur.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur."), Range(0.01, double.MaxValue, ErrorMessage = "Geçerli bir fiyat giriniz.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stok miktarı zorunludur."), Range(0, int.MaxValue, ErrorMessage = "Geçerli bir stok miktarı giriniz.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Lütfen bir resim seçiniz.")]
        public IFormFile? Image { get; set; } 
    }
}
