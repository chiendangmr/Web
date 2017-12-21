using HD.TVAD.Entities.Entities.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HD.TVAD.Entities.Repositories.Security
{
    public interface IUserRepository<TUser> : IRepository<TUser> where TUser : class
    {
        Task<IList<Guid>> GetUserPermissionIdsAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken));

        Task<IList<string>> GetUserPermissionNamesAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<Group>> GetGroupAndInheritableOfUser(Guid userId);
    }
}
