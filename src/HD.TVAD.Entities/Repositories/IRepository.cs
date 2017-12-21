using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Entities.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> Datas { get; }

        Task<int> InsertAsync(TEntity entry);

        Task<int> UpdateAsync(TEntity entry);

        Task<int> DeleteAsync(TEntity entry);

        Task<int> DeleteAsync(IEnumerable<TEntity> entries);

        Task<int> SaveChangesAsync();

        int SaveChanges();

        IDbContextTransaction BeginTransaction();
    }
}
