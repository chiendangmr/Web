using System;
using System.Collections.Generic;

namespace HDAutomation.Models
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
