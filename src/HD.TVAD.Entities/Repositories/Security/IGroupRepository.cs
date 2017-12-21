using HD.TVAD.Entities.Entities.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Entities.Repositories.Security
{
    public interface IGroupRepository<TGroup> : IRepository<TGroup> where TGroup : class
    {
        Task<bool> IsInPermission(TGroup group, Guid permissionId);

        Task<List<Permission>> GetAllPermission(Guid groupId, IList<Guid> permissionIds);
    }
}
