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
    public class ProductMapper:Profile
    {
        public ProductMapper()
        {
                CreateMap<ProductAdd_DTO, Product>().ReverseMap();
                CreateMap<ProductUpdate_DTO, Product>().ReverseMap();

        }
    

    }
}
