using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class SpotReportForPermamentCustomerParameter : Parameter
	{		
		[Display(Name = "Customer")]
		public Guid? CustomerId { get; set; }

		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }
		[Display(Name = "Is Group Children Contract")]
		public bool IsGroupChildrenContract { get; set; }
		[Display(Name = "Is Detail Contract Or Group")]
		public bool IsDetailContractOrGroup { get; set; }


		[Display(Name = "Position")]
		public string SignPersonPosition { get; set; }
		[Display(Name = "Name")]
		public string SignPersonName { get; set; }
	}
}
