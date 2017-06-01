using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblEmployments
    {
        public int EmploymentId { get; set; }
        public string EmploymentName { get; set; }
        public int? DepartmentId { get; set; }
        public int? JobTitleId { get; set; }
    }
}
