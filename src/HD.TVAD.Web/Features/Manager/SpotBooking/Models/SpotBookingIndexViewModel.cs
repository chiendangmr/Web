using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class SpotBookingIndexViewModel
    {
		public Guid AnnexContractAssetId { get; set; }
		public Guid AnnexContractId { get; set; }
		public SpotBookingCreateIndexViewModel SpotBookingCreateIndexViewModel { get; set; }
	}
}
