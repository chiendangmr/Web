using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using HD.TVAD.ApplicationCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HD.TVAD.Infrastructure.Repositories
{
	public abstract class Repository<T> : IRepository<T> where T : class
	{
		protected IDataContext _context;
		public Repository(IDataContext context)
		{
			_context = context;
		}

		public Task<int> Create(T item)
		{
			_context.Add(item);
			return SaveChanges();
		}

		private void Remove(T item)
		{
			_context.Remove(item);
		}
		private void UpdateWithoutSave(T item)
		{
			_context.Update(item);
		}
		public Task<int> Delete(T item)
		{
			_context.Remove(item);
			return SaveChanges();
		}

		public virtual IQueryable<T> Get(Guid id)
        {
            var obj = DbSet().Find(id);
            return List().Where(t => t == obj);
        }        
        public virtual DbSet<T> DbSet()
        {
            return (_context as DbContext).Set<T>();
        }

		public virtual IQueryable<T> List()
        {
            return (_context as DbContext).Set<T>();
        }

		public Task<int> SaveChanges()
		{
			return _context.SaveChangesAsync();
		}

		public Task<int> Update(T item)
		{
			_context.Update(item);
			return SaveChanges();
		}

		public Task<int> DeleteRange(ICollection<T> items)
		{
			foreach (var item in items)
			{
				Remove(item);
			}
			return SaveChanges();
		}
		public Task<int> UpdateRange(ICollection<T> items)
		{
			foreach (var item in items)
			{
				UpdateWithoutSave(item);
			}
			return SaveChanges();
		}

		public Task<int> DeleteThenUpdateRange(ICollection<T> oldItems, ICollection<T> newItems)
		{
			foreach (var item in oldItems)
			{
				Remove(item);
			}
			foreach (var item in newItems)
			{
				UpdateWithoutSave(item);
			}
			return SaveChanges();
		}
	}
}
