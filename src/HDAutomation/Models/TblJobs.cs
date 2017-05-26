using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblJobs
    {
        public int JobTitleId { get; set; }
        public decimal? JobSalary { get; set; }
        public string JobDescription { get; set; }
        public string Notes { get; set; }
    }
}
