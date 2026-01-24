using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;

namespace Onion.Application.Mapper
{
    public class FAQMapper:Profile
    {
        public FAQMapper()
        {
            CreateMap<FAQ, FAQ_DTO>().ReverseMap();
        }
    }
}
