using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.UIWebApp.Models;

namespace Onion.UIWebApp.UIMapper
{
    public class UIMapper:Profile
    {
        public UIMapper()
        {
            CreateMap<UserAdd_VM, UserAdd_DTO>().ReverseMap();

        }
    }
}
