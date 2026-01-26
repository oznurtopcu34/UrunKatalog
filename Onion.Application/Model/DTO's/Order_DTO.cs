namespace Onion.Application.Model.DTO_s
{
    public class Order_DTO
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool CanRequestReturn => (DateTime.Now - OrderDate).TotalDays <= 30;
      

    }
}
