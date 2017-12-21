using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HD.TVAD.ReportLibrary
{
	public class BroadcastCertificateWithValueSomeRetailContractParameter : Parameter
	{
		[Required]
		[Display(Name = "Annex Contract")]
		public IEnumerable<Guid> AnnexContractIds { get; set; }


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