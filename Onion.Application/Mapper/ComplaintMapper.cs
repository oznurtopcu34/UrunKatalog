using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;

namespace Onion.Application.Mapper
{
    public class ComplaintMapper:Profile
    {
        public ComplaintMapper()
        {
            CreateMap<Complaint, Complaint_DTO>().ReverseMap();
        }
    }
}
