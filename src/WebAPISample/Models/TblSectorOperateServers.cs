﻿using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblSectorOperateServers
    {
        public int Id { get; set; }
        public int? SectorId { get; set; }
        public int? OperateServerId { get; set; }
    }
}
