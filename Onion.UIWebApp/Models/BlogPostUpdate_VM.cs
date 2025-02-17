using System.ComponentModel.DataAnnotations;

namespace Onion.UIWebApp.Models
{
    public class BlogPostUpdate
    {
        [Required(ErrorMessage = "Ürün ID'si zorunludur.")]
        public int BlogPostID { get; set; } // Ürün ID'si

        [Required(ErrorMessage = "Başlık zorunludur.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik zorunludur.")]
        [MaxLength(1500, ErrorMessage = "Ürün açıklaması en fazla 1500 karakter olabilir.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public int ContentCategoryID { get; set; }

        [Required(ErrorMessage = "Lütfen bir resim seçiniz.")]
        public IFormFile? Image { get; set; }
    }
}
