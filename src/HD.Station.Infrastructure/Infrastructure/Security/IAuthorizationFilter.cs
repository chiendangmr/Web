using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Station.Infrastructure.Security
{
    public interface IAuthorizationFilter<TResource>
        where TResource : class
    {
        Task<IQueryable<TResource>> FilterAsync(IQueryable<TResource> query);
    }
}
