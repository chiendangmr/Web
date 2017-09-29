using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Positions
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public int? FirstPosition { get; set; }
        public int? LastPosition { get; set; }
    }
}
