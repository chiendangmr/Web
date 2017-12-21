using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    [Table("RetailContracts", Schema = "Booking")]
    public class AnnexContractRetail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Id))]
        public AnnexContract AnnexContractBase { get; set; }

        public int? OldId { get; set; }

        public AnnexContractRetail()
        {
            this.AnnexContractBase = new AnnexContract
            {
                Id = this.Id,
                AnnexContractRetail = this
            };
        }
    }
}
