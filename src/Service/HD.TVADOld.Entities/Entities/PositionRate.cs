using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblTiLeGiaViTri")]
    public class PositionRate
    {
        /// <summary>
        /// Start date
        /// </summary>
        [Key]
        [Column("NgayBatDau")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        [Column("TiLe")]
        public decimal Rate { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Column("GhiChu")]
        public string Description { get; set; }
    }
}
