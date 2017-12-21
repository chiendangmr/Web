using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Managers.User.Models
{
    public class UserSetViewModel
    {
        public Guid userId { get; set; }
    }

    public class UserGroupSetModel
    {
        public bool check { get; set; }

        public Guid id { get; set; }

        public Guid? parentId { get; set; }

        public string name { get; set; }
    }

    public class UserPermissionSetModel
    {
        public bool check { get; set; }

        public Guid id { get; set; }

        public Guid? parentId { get; set; }

        public string name { get; set; }
    }
}
