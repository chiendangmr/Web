using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportForCustomerByBookingType
{
	public class ValueReportForCustomerByBookingTypeViewModel
	{
		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }
		public string ContractCode { get; set; }
		public Decimal PriceBooking { get; set; }
		public Decimal DiscountValueBooking { get; set; }
		public Decimal TotalValueBooking { get; set; }
		public Decimal PriceSponsor { get; set; }
		public Decimal DiscountValueSponsor { get; set; }
		public Decimal TotalValueSponsor { get; set; }
		public Decimal PriceRetail { get; set; }
		public Decimal DiscountValueRetail { get; set; }
		public Decimal TotalValueRetail { get; set; }

		public Decimal TotalValue { get {

				return TotalValueBooking + TotalValueRetail + TotalValueSponsor;
					} }
	}
}
