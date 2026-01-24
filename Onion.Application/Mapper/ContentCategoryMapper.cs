using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;

namespace Onion.Application.Mapper
{
    public class ContentCategoryMapper:Profile
    {
        public ContentCategoryMapper()
        {   
            CreateMap<ContentCategory, ContentCategory_DTO>().ReverseMap();
            
        }
     

    }
}
