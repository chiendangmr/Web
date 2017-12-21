using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class ValueReportForCustomerByProductGroupParameter : Parameter
	{
		[Display(Name = "Product Groups")]
		public IEnumerable<Guid> ProductGroupIds { get; set; }
		[Display(Name = "Producers")]
		public IEnumerable<Guid> ProducerIds { get; set; }
		[Display(Name = "Product Name")]
		public string ProductName { get; set; }
	}
}
