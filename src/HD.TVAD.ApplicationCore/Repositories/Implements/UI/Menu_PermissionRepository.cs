using HD.Station;
using HD.TVAD.ApplicationCore.Entities.UI;
using HD.TVAD.ApplicationCore.Repositories.UI;
using HD.TVAD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Infrastructure.Repositories.UI
{
    [Service(ServiceType = typeof(IMenu_PermissionRepository))]
    public class Menu_PermissionRepository : Repository<Menu_Permission>, IMenu_PermissionRepository
    {
        public Menu_PermissionRepository(IDataContext context)
            : base(context)
        {

        }
    }
}
