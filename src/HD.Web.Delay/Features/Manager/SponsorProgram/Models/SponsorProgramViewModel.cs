using HD.TVAD.ApplicationCore.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class SponsorProgramViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "Parent")]
		public Guid? ParentId { get; set; }
		[Display(Name = "Contract Type", Prompt = "Code place")]
		public Guid? DefaultContractTypeId { get; set; }
		public string DefaultContractTypeName { get; set; }
		[Display(Name = "Code", Prompt = "Code place")]
		public string Code { get; set; }
		[Display(Name = "Name", Prompt = "Name place")]
		public string Name { get; set; }
		[Display(Name = "Description", Prompt = "Description place")]
		public string Description { get; set; }
		[Display(Name = "End Date", Prompt = "End Date")]
		public DateTime? EndDate { get; set; }

		public string CodeForSort
		{
			get
			{
				return Util.GetValueToSort(Code);
			}
		}
	}
}
