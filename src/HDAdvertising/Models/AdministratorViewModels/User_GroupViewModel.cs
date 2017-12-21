using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Models.AdministratorViewModels
{
    public partial class User_GroupViewModel
    {
        public Guid UserId { get; set; }

        public List<Guid> GroupIds { get; set; }
    }
}
