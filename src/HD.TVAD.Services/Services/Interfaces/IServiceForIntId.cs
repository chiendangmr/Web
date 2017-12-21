using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface IServiceForIntId<TEntity> where TEntity : class
	{
		IQueryable<TEntity> Get(int id);
		IQueryable<TEntity> GetAll();
		Task<int> Create(TEntity entity);
		Task<int> Update(TEntity entity);
		Task<int> Delete(TEntity entity);
	}
}
