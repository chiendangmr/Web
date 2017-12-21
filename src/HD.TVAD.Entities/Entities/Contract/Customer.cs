using HD.TVAD.Entities.Entities.Booking;
using HD.TVAD.Entities.Entities.Price;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Contract
{
    [Table("Customers", Schema = "Contract")]
    public class Customer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Customer type id
        /// </summary>
        public CustomerTypeEnum TypeId { get; set; }

        /// <summary>
        /// Customer type
        /// </summary>
        [ForeignKey(nameof(TypeId))]
        public CustomerType Type { get; set; }

        /// <summary>
        /// Name of customer
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Address of customer
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Customer is partner
        /// </summary>
        [ForeignKey(nameof(Id))]
        public PartnerCustomer PartnerCustomer { get; set; }

        /// <summary>
        /// Customer is retail
        /// </summary>
        [ForeignKey(nameof(Id))]
        public RetailCustomer RetailCustomer { get; set; }

        /// <summary>
        /// Annex contract
        /// </summary>
        [ForeignKey(nameof(AnnexContract.CustomerId))]
        public ICollection<AnnexContract> AnnexContracts { get; } = new HashSet<AnnexContract>();
    }
}
