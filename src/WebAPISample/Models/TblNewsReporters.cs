using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblNewsReporters
    {
        public long NewsId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int JobTitleId { get; set; }
        public double Salary { get; set; }
        public bool Paid { get; set; }
        public int NewsReporterId { get; set; }
    }
}
