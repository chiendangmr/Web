using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Contract
{
    [Table("CustomerTypes", Schema = "Contract")]
    public class CustomerType
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public CustomerTypeEnum Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Customers
        /// </summary>
        [ForeignKey(nameof(Customer.TypeId))]
        public ICollection<Customer> Customers { get; } = new HashSet<Customer>();
    }

    public enum CustomerTypeEnum : int
    {
        [Display(Name = "Retail customer")]
        Retail = 0,
        [Display(Name = "Permanent customer")]
        Permanent = 1,
        [Display(Name = "No permanent customer")]
        NoPermanent = 2
    }
}
