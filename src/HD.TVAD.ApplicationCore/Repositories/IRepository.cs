using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ApplicationCore.Repositories
{
	public interface IRepository<T> where T : class
	{
        DbSet<T> DbSet();
		IQueryable<T> List();
		Task<int> Create(T item);
		Task<int> Update(T item);
		Task<int> Delete(T item);
		Task<int> DeleteRange(ICollection<T> items);
		Task<int> UpdateRange(ICollection<T> items);
		Task<int> DeleteThenUpdateRange(ICollection<T> oldItems, ICollection<T> newItems);
		IQueryable<T> Get(Guid id);        
		Task<int> SaveChanges();
	}
}
