using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class ManageAccountIndexViewModel
	{
		[Display(Name = "Id")]
		public Guid Id { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter user name")]
		[Display(Name = "User name")]
		public string UserName { get; set; }

		[Display(Name = "Full name")]
		public string FullName { get; set; }

		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(Name = "Phone number")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Active")]
		public bool Active { get; set; }
	}
}
