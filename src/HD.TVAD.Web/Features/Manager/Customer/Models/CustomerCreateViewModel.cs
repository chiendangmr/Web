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
    public class CustomerCreateViewModel
    {
		
		public Guid Id { get; set; }
		[Required]
		[Display(Name = "Type")]
		public int TypeId { get; set; }
		[Display(Name = "Type Name")]
		public string TypeName { get; set; }
		[Required]
		[Display(Name = "Name", Prompt ="Name place")]
		public string Name { get; set; }
		[Display(Name = "Address", Prompt ="Address place")]
		public string Address { get; set; }

		[Display(Name = "Parent")]
		public Guid? ParentId { get; set; }
		[Required]
		[Display(Name = "Code", Prompt ="Code place")]
		public string Code { get; set; }
		[Display(Name = "Phone Number", Prompt ="Phone number place")]
		public string PhoneNumber { get; set; }
		[Display(Name = "Fax Number", Prompt ="Fax number place")]
		public string FaxNumber { get; set; }
		[Display(Name = "Representive Person", Prompt = "Representive Person place")]
		public string RepresentivePerson { get; set; }
		[Display(Name = "Position Of Representive Person", Prompt = "Position Of Representive Person place")]
		public string PositionOfRepresentivePerson { get; set; }
		[Display(Name = "Account Number", Prompt = "Account Number place")]
		public string AccountNumber { get; set; }
		[Display(Name = "Tax Number", Prompt = "Tax Number place")]
		public string TaxNumber { get; set; }
	}
}
