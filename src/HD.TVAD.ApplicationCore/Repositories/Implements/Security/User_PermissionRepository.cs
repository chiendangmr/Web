using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Security;
using HD.TVAD.ApplicationCore.Repositories.Security;
using HD.TVAD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Infrastructure.Repositories.Security
{
    [Service(ServiceType = typeof(IUser_PermissionRepository))]
    public class User_PermissionRepository : Repository<User_Permission>, IUser_PermissionRepository
    {
        public User_PermissionRepository(IDataContext context)
            : base(context)
        {

        }
    }
}
