using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("RetailTypes", Schema = "Price")]
    public class RetailType
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Id))]
        public PriceTypeDetail BaseType { get; set; }

        public string Description { get; set; }

        public int? OldId { get; set; }

        [ForeignKey(nameof(RetailPrice.RetailTypeId))]
        public ICollection<RetailPrice> Prices { get; } = new HashSet<RetailPrice>();

        public RetailType()
        {
            BaseType = new PriceTypeDetail
            {
                Id = this.Id,
                Retail = this
            };
        }
    }
}
