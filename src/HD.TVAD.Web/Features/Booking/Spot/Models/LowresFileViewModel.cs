using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class LowresFileViewModel
	{
		public Guid contentId { get; set; }
		public string src { get; set; }
		public string title { get; set; }
	}
}
