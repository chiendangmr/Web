using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
	public class RetailPriceEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		public Guid RetailTypeId { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public decimal Price { get; set; }
	}
}
