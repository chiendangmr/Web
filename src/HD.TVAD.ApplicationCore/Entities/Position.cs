using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Position
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public int? FirstPosition { get; set; }
        public int? LastPosition { get; set; }
    }
}
