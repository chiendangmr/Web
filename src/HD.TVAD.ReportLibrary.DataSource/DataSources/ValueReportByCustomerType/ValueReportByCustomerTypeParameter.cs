using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class ValueReportByCustomerTypeParameter : Parameter
	{
		[Display(Name = "Type")]
		public int Type { get; set; }

		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }

		public bool IsByValueOrDuration { get; set; }
		[Display(Name = "Report Without Discount")]
		public bool ReportWithoutDiscount { get; set; }
		/// <summary>
		/// 0: dai han, 1: ko thuong xuyen, 2: thu le, 3: tai tro, 4: chuong trinh
		/// </summary>
		[Display(Name = "Customer Type")]
		public int BookingTypeAndCustomerType { get; set; }
		/// <summary>
		/// 0: all : 1 0-10, 2 : 10-15: ...
		/// </summary>
		[Display(Name = "Duration")]
		public int AssetDurationType { get; set; }
	}

}