namespace Onion.UIWebApp.Models
{
    public class FAQ_VM
    {
        public int FAQID { get; set; }
        public string Question { get; set; }
        public string? Answer { get; set; }
        public int? AnsweredByUserID { get; set; }
        public DateTime? AnsweredDate { get; set; }
    }
}
