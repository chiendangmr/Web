using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblUsers
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public DateTime? LastActivity { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public int EmployeeId { get; set; }
        public bool? Enabled { get; set; }
    }
}
