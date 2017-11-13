using System;
using System.Linq;
using System.Linq.Expressions;
using Greenfinch.Business.Interface.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;


namespace Greenfinch.Data.Repositories
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        protected readonly DbContext Context;

        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="context"></param>
        public RepositoryBase(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Retrieves all rows related with TEntity
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        /// <summary>
        /// Retrieves the entity related with id parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Get(TKey id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> @where)
        {
            return Context.Set<TEntity>().AsExpandable().Where(where).AsQueryable();
        }

        /// <summary>
        /// Add a single entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Mark a entity was updated
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
        
  /// <summary>
        /// Remove the entity that the id represents
        /// </summary>
        /// <param name="id"></param>
        public virtual void Remove(TKey id)
        {
            Remove(Get(id));
        }

        /// <summary>
        /// Remove the entity that the model represents
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }
    }
}
