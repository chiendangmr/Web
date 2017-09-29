using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class CustomerTypes
    {
        public CustomerTypes()
        {
            Customers = new HashSet<Customers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
