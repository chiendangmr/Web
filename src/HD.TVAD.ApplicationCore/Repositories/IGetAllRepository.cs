using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ApplicationCore.Repositories
{
	public interface IGetAllRepository<T>
	{
		IQueryable<T> List(Guid id);
	}
}
