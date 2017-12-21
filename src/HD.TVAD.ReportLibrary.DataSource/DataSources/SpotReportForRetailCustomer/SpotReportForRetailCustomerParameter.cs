using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class SpotReportForRetailCustomerParameter : Parameter
	{
		[Display(Name = "Type")]
		public int Type { get; set; }

		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }


		[Display(Name = "Position")]
		public string SignPersonPosition { get; set; }
		[Display(Name = "Name")]
		public string SignPersonName { get; set; }
	}
}
