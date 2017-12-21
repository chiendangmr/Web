using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class SpotReportForCustomerByPositionChooseParameter : Parameter
	{
		[Required]
		[Display(Name = "Customer")]
		public Guid? CustomerId { get; set; }		

		/// <summary>
		/// 0: all, 1: phuluc quang cao, 2: phu luc tai tro
		/// </summary>
		[Display(Name = "AnnexContract Type")]
		public int AnnexContractType { get; set; }


		[Display(Name = "SponsorProgram")]
		public Guid? SponsorProgramId { get; set; }
				
	}
}
