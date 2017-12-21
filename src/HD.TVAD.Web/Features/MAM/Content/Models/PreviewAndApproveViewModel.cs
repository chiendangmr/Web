using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class PreviewAndApproveViewModel
    {
		public Guid ContentId { get; set; }
		public Guid WorkflowId { get; set; }
        public List<Station.MediaAssets.Models.AssetVM> AssetVMs { get; set; }
        public string ProviderId { get; set; }
	}
}