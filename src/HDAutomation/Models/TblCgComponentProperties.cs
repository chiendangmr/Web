using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblCgComponentProperties
    {
        public int Id { get; set; }
        public int? ComponentId { get; set; }
        public string ComponentPropertyName { get; set; }
        public int? PropertyId { get; set; }
    }
}
