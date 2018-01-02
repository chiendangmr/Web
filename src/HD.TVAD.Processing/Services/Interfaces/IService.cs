using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface IService<TEntity> where TEntity : class
	{
		IQueryable<TEntity> Get(Guid id);        
        IQueryable<TEntity> GetAll();
		Task<int> Create(TEntity entity);
		Task<int> Update(TEntity entity);
		Task<int> Delete(TEntity entity);
		Task<int> DeleteRange(ICollection<TEntity> entities);
		Task<int> UpdateRange(ICollection<TEntity> entities);
		Task<int> DeleteThenUpdateRange(ICollection<TEntity> oldEntities, ICollection<TEntity> newEntities);
	}
}
