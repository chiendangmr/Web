using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblNewsTypes
    {
        public int NewsTypeId { get; set; }
        public string Description { get; set; }
        public int? TblNewsTypesGroup { get; set; }
    }
}
