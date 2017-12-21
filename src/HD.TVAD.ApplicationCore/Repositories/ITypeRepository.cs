using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ApplicationCore.Repositories
{
	public interface ITypeRepository<T> where T : class
	{
		IQueryable<T> List();
	}
}
