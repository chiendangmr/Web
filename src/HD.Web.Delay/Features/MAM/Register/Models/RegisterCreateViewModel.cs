﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
	public class RegisterCreateViewModel
	{
		[Required]
		public String Code { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
	}
}