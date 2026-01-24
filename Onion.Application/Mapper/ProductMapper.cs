using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;


namespace Onion.Application.Mapper
{
    public class ProductMapper:Profile
    {
        public ProductMapper()
        {
                CreateMap<ProductAdd_DTO, Product>().ReverseMap();
                CreateMap<ProductUpdate_DTO, Product>().ReverseMap();

        }
    

    }
}
