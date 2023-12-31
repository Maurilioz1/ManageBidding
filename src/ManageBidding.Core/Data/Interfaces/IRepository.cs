﻿using System.Linq.Expressions;
using ManageBidding.Core.DomainObjects.Interfaces;

namespace ManageBidding.Core.Data.Interfaces
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        T Find(params object[] keys);
        T Find(Expression<Func<T, bool>> where);
        T Find(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, object> includes);
    }
}
