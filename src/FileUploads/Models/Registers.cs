using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Registers
    {
        public Registers()
        {
            Content = new HashSet<Content>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Content> Content { get; set; }
    }
}
