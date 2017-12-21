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
	public abstract class TypeRepository<T> : ITypeRepository<T> where T : class
	{
		protected IDataContext _context;
		public TypeRepository(IDataContext context)
		{
			_context = context;
		}
		public virtual IQueryable<T> List()
        {
            return (_context as DbContext).Set<T>();
        }
	}
}
