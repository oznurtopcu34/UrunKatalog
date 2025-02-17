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
    public class NewsMapper :Profile
    {
        public NewsMapper()
        {
            CreateMap<News, NewsAdd_DTO>().ReverseMap();
            CreateMap<News, NewsUpdate_DTO>().ReverseMap();
            CreateMap<News, News_DTO>().ReverseMap();
        }
    }
}
