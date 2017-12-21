using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class BroadcastCertificateWithValueManyContractParameter : Parameter
	{
		[Required]
		[Display( Name = "Customer")]
		public Guid? CustomerId { get; set; }
		[Display(Name = "Is Show Position")]
		public bool IsShowPosition { get; set; }


		[Display(Name = "A Organic Position")]
		public string A_OrganicPositionName { get; set; }
		[Display(Name = "A Organic Person")]
		public string A_OrganicPersonName { get; set; }
		[Display(Name = "B Organic Position")]
		public string B_OrganicPositionName { get; set; }
		[Display(Name = "B Organic Person")]
		public string B_OrganicPersonName { get; set; }
	}
}
