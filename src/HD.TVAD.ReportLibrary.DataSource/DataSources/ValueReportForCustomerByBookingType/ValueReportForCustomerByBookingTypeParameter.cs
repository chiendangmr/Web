using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class ValueReportForCustomerByBookingTypeParameter : Parameter
	{		
		[Display(Name = "Customer")]
		public Guid? CustomerId { get; set; }

		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }

		[Display(Name = "Report Without Discount")]
		public bool ReportWithoutDiscount { get; set; }

	}
}
