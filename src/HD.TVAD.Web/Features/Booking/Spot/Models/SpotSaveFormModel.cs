using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class SpotSaveFormModel
	{
		public Guid SpotId { get; set; }
		public IEnumerable<SpotAssetViewModel> SpotBookings { get; set; }
	//	public IEnumerable<Guid> AssetId { get; set; }

	}
}
