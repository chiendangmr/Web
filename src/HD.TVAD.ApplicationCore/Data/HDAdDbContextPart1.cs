using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace HD.TVAD.Infrastructure.Data
{
    public partial class HDAdDbContext :   IDataContext
    {
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public void AddRange<TEntity>(params TEntity[] entities) where TEntity : class
            => AddRange((IEnumerable<TEntity>)entities);

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
            => AddRange(entities.Cast<object>());

        public void AttachRange<TEntity>(params TEntity[] entities) where TEntity : class
            => AttachRange((IEnumerable<TEntity>)entities);

        public void AttachRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
            => AttachRange(entities.Cast<object>());

        public void UpdateRange<TEntity>(params TEntity[] entities) where TEntity : class
            => UpdateRange((IEnumerable<TEntity>)entities);

        public void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
            => UpdateRange(entities.Cast<object>());

        public void RemoveRange<TEntity>(params TEntity[] entities) where TEntity : class
            => RemoveRange((IEnumerable<TEntity>)entities);

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
            => RemoveRange(entities.Cast<object>());

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
			throw new NotImplementedException();
          //  return this.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
