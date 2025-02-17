using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Mapper
{
    public class BlogPostMapper :Profile
    {
        public BlogPostMapper()
        {
            CreateMap<BlogPost, BlogPostAdd_DTO>().ReverseMap();
            CreateMap<BlogPost, BlogPostUpdate_DTO>().ReverseMap();
            CreateMap<BlogPost, BlogPost_DTO>().ReverseMap();
        }
    }
}
