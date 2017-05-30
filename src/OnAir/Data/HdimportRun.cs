using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class HdimportRun
    {
        public long Id { get; set; }
        public long IdImport { get; set; }
        public DateTime StartTime { get; set; }

        public virtual Hdimport IdImportNavigation { get; set; }
    }
}
