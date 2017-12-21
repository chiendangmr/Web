using HD.TVAD.Entities.Entities.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("DiscountCustomers", Schema = "Price")]
    public class DiscountCustomer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public PartnerCustomer Customer { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal Rate { get; set; }

        public string Description { get; set; }
    }
}
