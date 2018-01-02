using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Security;
using HD.TVAD.ApplicationCore.Repositories.Security;
using HD.TVAD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Infrastructure.Repositories.Security
{
    [Service(ServiceType = typeof(IGroup_PermissionRepository))]
    public class Group_PermissionRepository : Repository<Group_Permission>, IGroup_PermissionRepository
    {
        public Group_PermissionRepository(IDataContext context)
            : base(context)
        {

        }
    }
}
