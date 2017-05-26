﻿using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblWorkflows
    {
        public int WorkflowId { get; set; }
        public string WorkflowName { get; set; }
        public int? WindowX { get; set; }
        public int? WindowY { get; set; }
        public string SerializeString { get; set; }
    }
}
