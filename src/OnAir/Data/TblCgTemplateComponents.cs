using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblCgTemplateComponents
    {
        public long Id { get; set; }
        public int? TemplateId { get; set; }
        public int? ComponentId { get; set; }
    }
}
