using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class SpotReportBySponsorProgramParameter : Parameter
	{
		[Display(Name = "Sponsor Program")]
		public Guid? SponsorProgramId { get; set; }

		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }
		[Display(Name = "Is Detail Contract Or Group")]
		public bool IsDetailContractOrGroup { get; set; }
		
	}
}
