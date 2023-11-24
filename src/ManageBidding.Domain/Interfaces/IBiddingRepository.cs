using ManageBidding.Domain.Models;
using ManageBidding.Core.Data.Interfaces;

namespace ManageBidding.Domain.Interfaces
{
    public interface IBiddingRepository : IRepository<Bidding>
    {
        Task<IEnumerable<Bidding>> Get();
        Task<Bidding> GetById(Guid id);
        void Create(Bidding bidding);
        void Update(Bidding bidding);
    }
}
