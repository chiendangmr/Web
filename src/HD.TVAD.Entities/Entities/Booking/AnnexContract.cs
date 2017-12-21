using HD.TVAD.Entities.Entities.Contract;
using HD.TVAD.Entities.Entities.Price;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    [Table("AnnexContracts", Schema = "Booking")]
    public class AnnexContract
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        [Required]
        [StringLength(256)]
        public string Code { get; set; }

        public Guid? ContractId { get; set; }

        [ForeignKey(nameof(ContractId))]
        public Contract.Contract Contract { get; set; }

        public BookingTypeEnum BookingTypeId { get; set; }

        [ForeignKey(nameof(BookingTypeId))]
        public BookingType BookingType { get; set; }

        public DateTime ReceiveDate { get; set; }

        [Column("AnnexContractTypeId")]
        public Guid? TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public AnnexContractType Type { get; set; }

        public string Creater { get; set; }

        [ForeignKey(nameof(Id))]
        public AnnexContractPartner AnnexContractPartner { get; set; }

        [ForeignKey(nameof(Id))]
        public AnnexContractRetail AnnexContractRetail { get; set; }

        [ForeignKey(nameof(AnnexContractContent.AnnexContractId))]
        public ICollection<AnnexContractContent> Contents { get; } = new HashSet<AnnexContractContent>();

        [ForeignKey(nameof(DiscountAnnexContract.AnnexContractId))]
        public ICollection<DiscountAnnexContract> Discounts { get; } = new HashSet<DiscountAnnexContract>();
    }
}
