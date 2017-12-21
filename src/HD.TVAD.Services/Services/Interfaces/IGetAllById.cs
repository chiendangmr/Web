using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface IGetAllById<TEntity> where TEntity : class
	{
		Task<List<TEntity>> GetAll(Guid id);
	}
}
