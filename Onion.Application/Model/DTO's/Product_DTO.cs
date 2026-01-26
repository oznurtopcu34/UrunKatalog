namespace Onion.Application.Model.DTO_s
{
    public class Product_DTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }  //fiyat     
        public string? Image { get; set; }  //resim
    }
}
