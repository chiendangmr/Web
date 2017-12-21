using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class RateSpotBlockEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int TypeId { get; set; }
		public Guid SpotBlockId { get; set; }
		public int SpotBlockDuration { get; set; }
		public string Rate { get; set; }
		public string TypeName { get; set; }
	}
}
