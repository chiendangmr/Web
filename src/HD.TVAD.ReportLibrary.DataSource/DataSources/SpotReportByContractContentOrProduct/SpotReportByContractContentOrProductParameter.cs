using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class SpotReportByContractContentOrProductParameter : Parameter
	{
		[Display(Name = "Type")]
		public int Type { get; set; }

		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }

		public bool IsByValueOrDuration { get; set; }
		[Display(Name = "Report Without Discount")]
		public bool ReportWithoutDiscount { get; set; }

		/// <summary>
		/// 0 : content
		/// 1: productname
		/// </summary>
		[Display(Name = "SearchType")]
		public int SearchType { get; set; }

		[Display(Name = "KeyWord", Prompt = "Keyword place")]
		public string KeyWord { get; set; }
	}
}