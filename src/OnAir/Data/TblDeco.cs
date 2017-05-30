using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblDeco
    {
        public int DecoId { get; set; }
        public string DecoName { get; set; }
        public int? DepartmentId { get; set; }
        public string DecoSpecs { get; set; }
        public DateTime? BuyDate { get; set; }
        public decimal? Price { get; set; }
        public int? StatusId { get; set; }
    }
}
