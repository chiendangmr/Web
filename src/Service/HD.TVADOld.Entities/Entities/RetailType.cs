using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblThongTinDonGian")]
    public class RetailType
    {
        [Column("MaThongTinDonGian")]
        [Key]
        public RetailTypeEnum Id { get; set; }

        [Column("MoTa")]
        public string Description { get; set; }

        [ForeignKey(nameof(AnnexContractRetailContent.RetailTypeId))]
        public ICollection<AnnexContractRetailContent> AnnexContractContents { get; } = new HashSet<AnnexContractRetailContent>();

        [ForeignKey(nameof(RetailPrice.RetailTypeId))]
        public ICollection<RetailPrice> Prices { get; } = new HashSet<RetailPrice>();
    }

    public enum RetailTypeEnum : int
    {
        Free = 0,
        Notify = 1,
        Simple = 2,
        Ceiling = 3,
        Special = 4
    }
}
