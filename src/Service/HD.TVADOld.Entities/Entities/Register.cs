using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblDonViGui")]
    public class Register
    {
        [Column("MaDonViGui")]
        [Key]
        public int Id { get; set; }

        [Column("TenDonViGui")]
        public string Name { get; set; }

        [Column("KiTuDaiDien")]
        public string Code { get; set; }

        [ForeignKey(nameof(Content.RegisterId))]
        public ICollection<Content> Contents { get; } = new HashSet<Content>();
    }
}
