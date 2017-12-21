using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForCustomerByPositionChoose
{
	public class SpotReportForCustomerByPositionChooseViewModel
	{
		public string AnnexContractCode { get; set; }
		public string AssetCode { get; set; }
		public string ProductName { get; set; }
		public int AssetDuration { get; set; }
		public string TimeBandName { get; set; }
		public decimal? Price { get; set; }
		public int SpotCount { get; set; }
		public int PositionChooseCount { get; set; }
		public decimal? TotalPrice
		{
			get
			{
				if (Price == null || SpotCount <= 0) return null;
				else return (decimal)Price * SpotCount;
			}
		}
		public decimal? PositionCost { get; set; }
		public decimal? DiscountRate { get; set; }
		public decimal? TotalPriceAfterDiscount
		{
			get
			{
				if (TotalPrice == null) return null;
				else if (DiscountRate == null || DiscountRate == 0)
					return TotalPrice;
				else return (decimal)TotalPrice * (100 - (decimal)DiscountRate) / 100;
			}
		}
		public decimal? PositionCostAfterDiscount
		{
			get
			{
				if (PositionCost == null) return null;
				else if (DiscountRate == null || DiscountRate == 0) return PositionCost;
				else return (decimal)PositionCost * (100 - (decimal)DiscountRate) / 100;
			}
		}
		public decimal? TotalValue
		{
			get
			{
				decimal tien = TotalPriceAfterDiscount == null ? 0 : (decimal)TotalPriceAfterDiscount;
				if (PositionCostAfterDiscount != null) tien += (decimal)PositionCostAfterDiscount;
				return tien;
			}
		}
		public string DayHasPositionChoose { get; set; }

	}
}
