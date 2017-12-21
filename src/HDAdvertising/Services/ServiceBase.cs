using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Services
{
    public class ServiceBase<TEntity, TContext> : IService<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        readonly TContext _Context;

        public ServiceBase(TContext context)
        {
            _Context = context;
        }

        public virtual DbSet<TEntity> DataSets
        {
            get
            {
                return _Context.Set<TEntity>();
            }
        }

        public virtual IQueryable<TEntity> Datas
        {
            get
            {
                return _Context.Set<TEntity>();
            }
        }

        public virtual Task<int> Create(TEntity entity)
        {
            _Context.Set<TEntity>().Add(entity);
            return _Context.SaveChangesAsync();
        }

        public virtual Task<int> Update(TEntity entity)
        {
            return _Context.SaveChangesAsync();
        }

        public virtual Task<int> Delete(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
            return _Context.SaveChangesAsync();
        }

        public virtual Task<int> Delete(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().RemoveRange(entities);
            return _Context.SaveChangesAsync();
        }

        public virtual Task<int> SaveAllChanged()
        {
            return _Context.SaveChangesAsync();
        }
    }
}
