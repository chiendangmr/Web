﻿using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblLiveSourcePorts
    {
        public int LiveSourceId { get; set; }
        public int? RouterId { get; set; }
        public int? PortOutput { get; set; }
        public string LiveSourceDescription { get; set; }
    }
}
