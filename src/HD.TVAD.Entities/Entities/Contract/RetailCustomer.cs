using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Contract
{
    /// <summary>
    /// Ratail customer
    /// </summary>
    [Table("RetailCustomers", Schema = "Contract")]
    public class RetailCustomer
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Base customer
        /// </summary>
        [ForeignKey(nameof(Id))]
        public Customer BaseCustomer { get; set; }

        public RetailCustomer()
        {
            BaseCustomer = new Customer
            {
                Id = this.Id,
                RetailCustomer = this
            };
        }
    }
}
