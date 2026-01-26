

namespace Onion.Application.Model.DTO_s
{
    public class BlogPost_DTO
    {
        public int BlogPostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; }
        public int ContentCategoryID { get; set; }
        public string? ContentCategoryName { get; set; }
    }
}
