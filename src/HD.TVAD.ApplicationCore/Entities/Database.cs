﻿using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Database
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
