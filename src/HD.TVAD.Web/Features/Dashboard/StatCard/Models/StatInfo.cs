using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class StatInfo
	{
		public decimal Count { get; set; }
		public decimal Change { get; set; }
		public string DeltaClass {
			get {
				return Change > 0 ? "positive" : "negative";
			}
		}
    }
}
