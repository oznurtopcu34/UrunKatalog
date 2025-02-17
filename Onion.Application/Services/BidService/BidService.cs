using AutoMapper;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Enums;
using Onion.Domain.Models;
using Onion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.BidService
{
    public class BidService : IBidService
    {


            private readonly IBidRepository _bidRepository;
            private readonly IMapper _mapper;

            public BidService(IBidRepository bidRepository, IMapper mapper)
            {
                _bidRepository = bidRepository;
                _mapper = mapper;
            }

            //  Kullanıcı teklif verir
            public async Task<bool> PlaceBidAsync(Bid_DTO bidDTO)
            {
                var bidEntity = _mapper.Map<Bid>(bidDTO);
                bidEntity.Status = ReturnStatus.Pending; // Varsayılan olarak beklemede
                return await _bidRepository.AddAsync(bidEntity) > 0;
            }

            //  Admin panelinde bekleyen teklifleri getirir
            public async Task<List<Bid_DTO>> GetPendingBidsAsync()
            {
                var bids = await _bidRepository.GetPendingBidsAsync();
                return _mapper.Map<List<Bid_DTO>>(bids);
            }
        //teklif kabulu
        public async Task<bool> ApproveBidAsync(int id)
        {
            var bid = await _bidRepository.GetByIdAsync(id);
            if (bid != null)
            {
                bid.Status = ReturnStatus.Approved;
                bid.UpdatedDate = DateTime.Now;
                await _bidRepository.UpdateAsync(bid);
                return true; 
            }
            return false;
        }
        //teklif reddi
        public async Task<bool> RejectBidAsync(int id)
        {
            var bid = await _bidRepository.GetByIdAsync(id);
            if (bid != null)
            {
                bid.Status = ReturnStatus.Rejected;
                bid.UpdatedDate = DateTime.Now;
                await _bidRepository.UpdateAsync(bid);
                return true; 
            }
            return false;
        }

    }
}

