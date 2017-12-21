using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HD.TVAD.ReportLibrary
{
	public class BroadcastCertificateSomeContractParameter : Parameter
	{
	//	[Required]
		[Display(Name = "Annex Contracts")]
		public IEnumerable<Guid> AnnexContractIds { get; set; }


		[Display(Name = "Sign person")]
		public string SignPerson { get; set; }
	}
}