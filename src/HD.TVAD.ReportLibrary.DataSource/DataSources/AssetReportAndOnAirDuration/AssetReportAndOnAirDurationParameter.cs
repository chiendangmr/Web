using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class AssetReportAndOnAirDurationParameter : Parameter
	{
		[Display(Name = "Channel")]
		public IEnumerable<Guid> ChannelIds { get; set; }

		/// <summary>
		/// 0: all, 1: no retail, 2: only retail
		/// </summary>
		public int BookingType { get; set; } // 

		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }


		public bool InsertCurrentOrBroadcastDate { get; set; }
	}
}