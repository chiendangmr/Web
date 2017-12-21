using System;
using System.ComponentModel.DataAnnotations;

namespace HD.TVAD.Web.Features.Managers.UserGroup.Models
{
    public class UserGroupViewModel
    {
        [Display(Name = "Id")]
        public Guid id { get; set; }

        [Display(Name = "Parent Id")]
        public Guid? parentId { get; set; }

        [Required(ErrorMessage = "The name field is required")]
        [Display(Name = "User group name")]
        public string name { get; set; }
		[Display(Name = "Active")]
		public bool active { get; set; }
	}
}
