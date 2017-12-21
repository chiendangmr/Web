using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Managers.UserGroup.Models
{
    public class GroupPermissionViewModel
    {
        [Display(Name = "Has permission")]
        public bool check { get; set; }

        [Display(Name = "Group Id")]
        public Guid groupId { get; set; }

        [Display(Name = "Permission Id")]
        public Guid permissionId { get; set; }

        [Display(Name = "Parent permission Id")]
        public Guid? permissionParentId { get; set; }

        [Display(Name = "Permission name")]
        public string permissionDisplayName { get; set; }
    }
}
