﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Model.DTO_s
{
    public class BlogPostAdd_DTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int ContentCategoryID { get; set; }
    }
}
