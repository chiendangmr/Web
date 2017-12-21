using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        DbSet<TEntity> DataSets { get; }

        IQueryable<TEntity> Datas { get; }

        Task<int> Create(TEntity entity);

        Task<int> Update(TEntity entity);

        Task<int> Delete(TEntity entity);

        Task<int> Delete(IEnumerable<TEntity> entities);

        Task<int> SaveAllChanged();
    }
}
