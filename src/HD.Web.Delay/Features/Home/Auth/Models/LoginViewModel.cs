using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Home.Auth.Models
{
    public class LoginViewModel
	{
		[Required]
		[Display(Name = "User name", Prompt = "User name place")]
		public string UserName { get; set; }

		[Required]
		[Display(Name = "Password", Prompt = "Password place")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
	}
}
