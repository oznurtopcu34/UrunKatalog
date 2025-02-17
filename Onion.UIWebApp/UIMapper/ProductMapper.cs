using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.UIWebApp.Models;

namespace Onion.UIWebApp.UIMapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductAdd_VM, ProductAdd_DTO>().ReverseMap();
            CreateMap<ProductUpdate_VM, ProductUpdate_DTO>().ReverseMap();

        }
    }
}
