﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
	public class ProductGroupEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
		public String Code { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public Guid? ParentId { get; set; }
	}
}