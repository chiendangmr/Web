using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class UserGroupCreateViewModel
	{
		[Required]
		[Display(Name = "Parent")]
		public Guid ParentId { get; set; }

		[Required(ErrorMessage = "The name field is required")]
		[Display(Name = "User group name", Prompt = "User group name place")]
		public string Name { get; set; }
	}
}
