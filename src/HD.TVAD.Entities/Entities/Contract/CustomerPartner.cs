using HD.TVAD.Entities.Entities.Price;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Contract
{
    /// <summary>
    /// Partner customer
    /// </summary>
    [Table("CustomerPartners", Schema = "Contract")]
    public class PartnerCustomer
    {
        // Id
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Base customer
        /// </summary>
        [ForeignKey(nameof(Id))]
        public Customer BaseCustomer { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Code { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Fax
        /// </summary>
        [StringLength(50)]
        public string FaxNumber { get; set; }

        /// <summary>
        /// Representive person
        /// </summary>
        public string RepresentivePerson { get; set; }

        /// <summary>
        /// Position of representive person
        /// </summary>
        public string PositionOfRepresentivePerson { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        [StringLength(50)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Tax number
        /// </summary>
        [StringLength(50)]
        public string TaxNumber { get; set; }

        /// <summary>
        /// Contracts
        /// </summary>
        [ForeignKey(nameof(Contract.CustomerId))]
        public ICollection<Contract> Contracts { get; } = new HashSet<Contract>();

        [ForeignKey(nameof(DiscountCustomer.CustomerId))]
        public ICollection<DiscountCustomer> Discounts { get; } = new HashSet<DiscountCustomer>();

        /// <summary>
        /// Id of old system
        /// </summary>
        public int? OldId { get; set; }

        public PartnerCustomer()
        {
            BaseCustomer = new Customer { Id = this.Id };
        }
    }
}
