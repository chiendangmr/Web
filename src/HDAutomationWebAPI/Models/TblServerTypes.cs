using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblServerTypes
    {
        public int ServerTypeId { get; set; }
        public string ServerTypeName { get; set; }
        public string ClassName { get; set; }
        public string DllName { get; set; }
    }
}
