using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblChuongTrinhTaiTro")]
    public class SponsorProgram
    {
        /// <summary>
        /// Id
        /// </summary>
        [Column("IDChuongTrinh")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [Column("MaChuongTrinh")]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Column("TenChuongTrinh")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("NgayKetThuc")]
        public DateTime? EndDate { get; set; }

        [Column("GhiChu")]
        public string Description { get; set; }

        [ForeignKey(nameof(AnnexContractPartner.SponsorProgramId))]
        public ICollection<AnnexContractPartner> AnnexContractPartners { get; } = new HashSet<AnnexContractPartner>();

        [ForeignKey(nameof(DiscountSponsorProgram.SponsorProgramId))]
        public ICollection<DiscountSponsorProgram> Discounts { get; } = new HashSet<DiscountSponsorProgram>();
    }
}
