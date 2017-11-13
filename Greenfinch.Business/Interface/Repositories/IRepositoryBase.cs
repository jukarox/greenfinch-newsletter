using System;
using System.Linq;
using System.Linq.Expressions;

namespace Greenfinch.Business.Interface.Repositories
{
    public interface IRepositoryBase<TEntity, in TKey> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(TKey id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TKey id);
        void Remove(TEntity entity);
    }
}