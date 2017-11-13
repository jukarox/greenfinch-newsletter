using System;
using System.Collections.Generic;
using System.Text;

namespace Greenfinch.Business.Interface.Services
{
    public interface IServiceBase<TEntity, in TKey> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
