using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class PreviewIndexViewModel
	{
		public Guid SpotId { get; set; }
		public IList<LowresFileViewModel> LowresFiles { get; set; }
	}
}
