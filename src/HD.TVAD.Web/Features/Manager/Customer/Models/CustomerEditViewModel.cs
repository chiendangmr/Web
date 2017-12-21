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
    public class CustomerEditViewModel
    {
		
		public Guid Id { get; set; }
		[Required]
		public int TypeId { get; set; }
		public string TypeName { get; set; }
		[Required]
		public string Name { get; set; }
		public string Address { get; set; }

		public Guid? ParentId { get; set; }
		public string Code { get; set; }
		public string PhoneNumber { get; set; }
		public string FaxNumber { get; set; }
		public string RepresentivePerson { get; set; }
		public string PositionOfRepresentivePerson { get; set; }
		public string AccountNumber { get; set; }
		public string TaxNumber { get; set; }
	}
}
