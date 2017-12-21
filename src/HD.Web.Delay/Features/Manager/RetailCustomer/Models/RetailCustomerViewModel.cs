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
    public class RetailCustomerViewModel
    {
		public Guid Id { get; set; }
		[Display(Name = "Type")]
		public int TypeId { get; set; }
		[Display(Name = "Type Name")]
		public int TypeName { get; set; }
		[Required]
		[Display(Name = "Name",Prompt ="Name place")]
		public string Name { get; set; }
		[Display(Name = "Address", Prompt ="Address place")]
		public string Address { get; set; }

	}
}
