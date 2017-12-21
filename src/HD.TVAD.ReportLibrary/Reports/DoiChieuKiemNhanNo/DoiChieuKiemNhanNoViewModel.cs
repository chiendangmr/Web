using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsLibrary
{
	public class DoiChieuKiemNhanNoViewModel
	{
		public string Group { get; set; }
		public int Type { get; set; }
		public string AnnexContractCode { get; set; }
		public string CustomerName { get; set; }
		public string Content { get; set; }
		public string SpotId { get; set; }
		public int Duration { get; set; }
		public int PositionChoose { get; set; }
		public Decimal Price { get; set; }
		public Decimal PositionCost { get; set; }
		public Decimal DiscountRate { get; set; }
		public Decimal DiscountValue { get; set; }
		public Decimal TotalValue { get; set; }

	}
}
