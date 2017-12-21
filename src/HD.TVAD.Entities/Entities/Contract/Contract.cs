using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Contract
{
    [Table("Contracts", Schema = "Contract")]
    public class Contract
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public PartnerCustomer Customer { get; set; }

        [Required]
        [StringLength(256)]
        public string Code { get; set; }

        public string Content { get; set; }

        public DateTime? SignDate { get; set; }
    }
}
