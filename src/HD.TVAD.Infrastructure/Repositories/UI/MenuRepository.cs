using HD.Station;
using HD.TVAD.ApplicationCore.Entities.UI;
using HD.TVAD.ApplicationCore.Repositories.UI;
using HD.TVAD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Infrastructure.Repositories.UI
{
    [Service(ServiceType = typeof(IMenuRepository))]
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(IDataContext context)
            : base(context)
        {

        }
    }
}
