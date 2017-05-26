using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblDepartments
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? ParentDepartmentId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
    }
}
