using ManageBidding.Core.Data.Interfaces;
using ManageBidding.Domain.Models;

namespace ManageBidding.Domain.Interfaces
{
    public interface IBiddingRepository : IRepository<Bidding>
    {
        Task<IEnumerable<Bidding>> Get();
        Task<Bidding> GetById();
        void Create(Bidding bidding);
        void Update(Bidding bidding);
    }
}
