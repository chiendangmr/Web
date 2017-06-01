using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblEmployees
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Ssn { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int? MajorSpeciality { get; set; }
        public int? SecondarySpeciality { get; set; }
        public int? HighestDegreeId { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? ExpireDateOfContact { get; set; }
        public double? BasicSalaryCoefficient { get; set; }
        public int? JobTitleId { get; set; }
        public int? DepartmentId { get; set; }
        public bool? Sex { get; set; }
    }
}
