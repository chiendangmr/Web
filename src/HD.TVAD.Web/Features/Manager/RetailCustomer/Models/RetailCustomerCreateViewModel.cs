using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using HD.TVAD.ApplicationCore.Entities;

namespace HD.TVAD.Web.Models
{
    public class RetailCustomerCreateViewModel
    {
		
		public Guid Id { get; set; }
		[Required]
		[Display(Name = "Type")]
		public int TypeId { get; set; }
		[Display(Name = "Type Name")]
		public int TypeName { get; set; }
		[Required]
		[Display(Name = "Name")]
		public string Name { get; set; }
		[Display(Name = "Address")]
		public string Address { get; set; }
		
	}
}
