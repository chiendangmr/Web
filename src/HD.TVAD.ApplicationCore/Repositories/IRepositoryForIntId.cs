using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ApplicationCore.Repositories
{
	public interface IRepositoryForIntId<T>
	{
		IQueryable<T> List();
		Task<int> Create(T item);
		Task<int> Update(T item);
		Task<int> Delete(T item);
		IQueryable<T> Get(int id);
		Task<int> SaveChanges();
	}
}
