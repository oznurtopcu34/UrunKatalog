using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.UIWebApp.Models;

namespace Onion.UIWebApp.UIMapper
{
    public class BlogPostMapper:Profile
    {
        public BlogPostMapper()
        {
            CreateMap<BlogPost_VM, BlogPostAdd_DTO>().ReverseMap();
        }
    }
}
