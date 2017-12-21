using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class StatCardViewModel
	{
		public StatCardViewModel()
		{
			StatCards = new Dictionary<string, StatInfo>();
		}
		public IDictionary<string, StatInfo> StatCards { get; set; }
	}
}
