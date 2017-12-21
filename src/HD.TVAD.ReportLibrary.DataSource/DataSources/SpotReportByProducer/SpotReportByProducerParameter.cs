using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class SpotReportByProducerParameter : Parameter
	{
		[Display(Name = "Type")]
		public int Type { get; set; }

		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }

		/// <summary>
		/// Tach rieng tung san pham
		/// </summary>
		[Display(Name = "Take Product Name")]
		public bool IsTakeProductName { get; set; }

		[Display(Name = "SelectAllProducerOrByOne")]
		public bool SelectAllProducerOrByOne { get; set; }
		[Display(Name = "Producer")]
		public IEnumerable<Guid> ProducerIds { get; set; }

	}
}
