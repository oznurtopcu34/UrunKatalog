using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;

namespace Onion.Application.Mapper
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, Category_DTO>().ReverseMap();
        }
    }
}
