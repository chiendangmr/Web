using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Security;
using HD.TVAD.ApplicationCore.Repositories.Security;
using HD.TVAD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Infrastructure.Repositories.Security
{
    [Service(ServiceType = typeof(IGroup_UserRepository))]
    public class Group_UserRepository : Repository<Group_User>, IGroup_UserRepository
    {
        public Group_UserRepository(IDataContext context)
            : base(context)
        {

        }
    }
}
