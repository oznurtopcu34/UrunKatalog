using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;


namespace Onion.Application.Mapper
{
    public class BidMapper:Profile
    {
        public BidMapper()
        {
            CreateMap<Bid, Bid_DTO>().ReverseMap();
        }
    }
}
