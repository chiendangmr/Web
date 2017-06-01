using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblSalaryItem
    {
        public int SalaryItemId { get; set; }
        public int EmployeeId { get; set; }
        public int? SalaryReport { get; set; }
        public double Salary { get; set; }
        public double Bonus { get; set; }
    }
}
