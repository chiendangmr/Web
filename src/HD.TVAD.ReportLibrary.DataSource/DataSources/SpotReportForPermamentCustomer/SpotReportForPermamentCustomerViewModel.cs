﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForPermamentCustomer
{
	public class SpotReportForPermamentCustomerViewModel
	{
		public int Index { get; set; }
		public string CustomerCode { get; set; }
		public string ContractCode { get; set; }
		public string CustomerName { get; set; }
		public int AssetDuration { get; set; }
		public Decimal? Price { get; set; }
		public Decimal? PositionCost { get; set; }
		public Decimal? DiscountRate { get; set; }
		public Decimal? DiscountValue { get; set; }
		public Decimal? TotalValue { get {
				return Price.GetValueOrDefault() + PositionCost.GetValueOrDefault() - DiscountValue.GetValueOrDefault();
			} }
	}
}