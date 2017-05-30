using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class Hdimport
    {
        public long Id { get; set; }
        public long Idclip { get; set; }
        public DateTime CreateTime { get; set; }
        public string FileSource { get; set; }
        public int Status { get; set; }
        public int Ntry { get; set; }
        public string FileCurrent { get; set; }
        public string Message { get; set; }

        public virtual HdimportRun HdimportRun { get; set; }
        public virtual InforTape IdclipNavigation { get; set; }
    }
}
