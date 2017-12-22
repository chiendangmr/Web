﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ImportedTVCWithCustomer
{
	public class ImportedTVCWithCustomerViewModel
	{
		public DateTime BroadcastDate { get; set; }
		public string ChannelName { get; set; }
		public string TimeBandName { get; set; }
		public string TimeBandDescription { get; set; }
		public string TimeBandSlice { get; set; }
		public string TimeBandSliceDescription { get; set; }
		public string TimeBandTime { get; set; }
		public string ContractCode { get; set; }
		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }


		public int Page { get; set; }
		public string NotePage { get; set; }
		public int CutOrder { get; set; }

		public int OnAirIndex { get; set; }

		public int BookingTypeId { get; set; }
		public string AssetCode { get; set; }
		public string Content { get; set; }
		public int AssetDuration { get; set; }
		public int FreeDuration { get; set; }
		public string BroadcastDateText
		{
			get
			{
				return Util.GetTextDate(BroadcastDate);
			}
		}
		public decimal PositionCost { get; set; }
	}
}