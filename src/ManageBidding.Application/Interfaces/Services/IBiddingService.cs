using ManageBidding.Domain.Models;
using ManageBidding.Application.ViewModels;

namespace ManageBidding.Application.Interfaces.Services
{
    public interface IBiddingService : IDisposable
    {
        Task<IEnumerable<BiddingViewModel>> Get();
        Task<BiddingViewModel> GetById(Guid id);
        Task<Bidding> Create(BiddingViewModel biddingViewModel);
        Task<Bidding> Update(BiddingViewModel biddingViewModel);
        Task<bool> Delete(Guid id);
    }
}
