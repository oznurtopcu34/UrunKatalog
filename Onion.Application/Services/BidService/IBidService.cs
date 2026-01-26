using Onion.Application.Model.DTO_s;

namespace Onion.Application.Services.BidService
{
    public interface IBidService
    {
        Task<bool> PlaceBidAsync(Bid_DTO bidDTO);    //  Kullanıcı teklif verir
        Task<List<Bid_DTO>> GetPendingBidsAsync();   //  Admin panelinde bekleyen teklifleri getirir
        Task<bool> ApproveBidAsync(int id); //teklif kabulu
        Task<bool> RejectBidAsync(int id); //teklif reddi
    }
}
