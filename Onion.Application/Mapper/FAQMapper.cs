﻿using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
