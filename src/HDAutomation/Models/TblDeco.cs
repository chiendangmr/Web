using System;
using System.Collections.Generic;

namespace HDAutomation.Models
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
