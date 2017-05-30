using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblSalaryReport
    {
        public int ReportId { get; set; }
        public bool Approved { get; set; }
        public DateTime? DateApproved { get; set; }
        public int? TblUserApproving { get; set; }
        public DateTime DateCreat { get; set; }
    }
}
