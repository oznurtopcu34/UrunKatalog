using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.UIWebApp.Models;

namespace Onion.UIWebApp.UIMapper
{
    public class FAQMapper:Profile
    {
        public FAQMapper()
        {
            CreateMap<FAQ_VM, FAQ_DTO>().ReverseMap();
        }
    }
}
