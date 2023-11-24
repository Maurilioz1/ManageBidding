using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ManageBidding.Domain.Models;
using ManageBidding.Domain.Interfaces;
using ManageBidding.Core.Data.Interfaces;
using ManageBidding.Data.EntityFramework.Context;

namespace ManageBidding.Data.EntityFramework.Repositories
{
    public class BiddingRepository : IBiddingRepository
    {
        private readonly ManageBiddingContext _context;

        protected DbSet<Bidding> DbSet
        {
            get
            {
                return _context.Set<Bidding>();
            }
        }

        public IUnitOfWork UnitOfWork => _context;

        public BiddingRepository(ManageBiddingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bidding>> Get()
        {
            return await _context.Biddings.AsNoTracking().Where(b => b.Active).ToArrayAsync();
        }

        public async Task<Bidding> GetById(Guid id)
        {
            return await _context.Biddings.AsNoTracking().Where(b => b.Active).FirstOrDefaultAsync(b => b.Id == id);
        }

        public void Create(Bidding bidding)
        {
            _context.Biddings.Add(bidding);
        }

        public void Update(Bidding bidding)
        {
            _context.Biddings.Update(bidding);
        }

        public Bidding Find(params object[] keys)
        {
            try
            {
                return DbSet.Find(keys);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Bidding Find(Expression<Func<Bidding, bool>> where)
        {
            try
            {
                return DbSet.AsNoTracking().FirstOrDefault(where);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Bidding Find(Expression<Func<Bidding, bool>> predicate, Func<IQueryable<Bidding>, object> includes)
        {
            try
            {
                IQueryable<Bidding> _query = DbSet;

                if (includes != null)
                {
                    _query = includes(_query) as IQueryable<Bidding>;
                }

                return _query.SingleOrDefault(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
