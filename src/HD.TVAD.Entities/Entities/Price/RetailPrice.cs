using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("RetailPrices", Schema = "Price")]
    public class RetailPrice
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid RetailTypeId { get; set; }

        [ForeignKey(nameof(RetailTypeId))]
        public RetailType RetailType { get; set; }

        public DateTime StartDate { get; set; }

        public decimal Price { get; set; }
    }
}
