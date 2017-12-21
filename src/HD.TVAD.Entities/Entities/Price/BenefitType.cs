using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("BenefitTypes", Schema = "Price")]
    public class BenefitType
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Id))]
        public PriceTypeDetail BaseType { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(BenefitPrice.BenefitTypeId))]
        public ICollection<BenefitPrice> Prices { get; } = new HashSet<BenefitPrice>();

        public BenefitType()
        {
            BaseType = new PriceTypeDetail
            {
                Id = this.Id,
                BenefitType = this
            };
        }
    }
}
