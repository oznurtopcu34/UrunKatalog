namespace Onion.Application.Model.DTO_s
{
    public class Bid_DTO
    {
        public int BidID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal OfferedPrice { get; set; }
    }
}
