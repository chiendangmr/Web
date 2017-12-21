using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportByContractType
{
	public class SpotReportByContractTypeViewModel
	{
		public string AreaType { get; set; }
		public string ContractType { get; set; }
		public int AssetDuration { get; set; }
		public decimal Price { get; set; }
		public decimal PositionCost { get; set; }
		public decimal DiscountValue { get; set; }
		public decimal TotalValue {
			get {
				return Price + PositionCost - DiscountValue;
			} }
	}
}
