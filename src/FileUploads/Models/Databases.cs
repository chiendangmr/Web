using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Databases
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
