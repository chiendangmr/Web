using System;
using System.ComponentModel.DataAnnotations;

namespace HD.TVAD.ReportLibrary
{
	public class BroadcastCertificateParameter : Parameter
	{
		[Required]
		[Display(Name = "Annex Contract")]
		public Guid AnnexContractId { get; set; }


		[Display(Name = "Sign person")]
		public string SignPerson { get; set; }
	}
}