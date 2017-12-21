using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class SpotReportByContractTypeParameter : Parameter
	{
		[Display(Name = "Type")]
		public int Type { get; set; }

		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }

	}
}