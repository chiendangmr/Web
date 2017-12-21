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
	public abstract class RepositoryForIntId<T> : IRepositoryForIntId<T> where T : class
	{
		protected IDataContext _context;
		public RepositoryForIntId(IDataContext context)
		{
			_context = context;
		}

		public Task<int> Create(T item)
		{
			_context.Add(item);
			return SaveChanges();
		}

		public Task<int> Delete(T item)
		{
			_context.Remove(item);
			return SaveChanges();
		}

		abstract public IQueryable<T> Get(int id);        
		abstract public IQueryable<T> List();

		public Task<int> SaveChanges()
		{
			return _context.SaveChangesAsync();
		}

		public Task<int> Update(T item)
		{
			_context.Update(item);
			return SaveChanges();
		}
	}
}
