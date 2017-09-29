using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class CustomerRetails
    {
        public Guid Id { get; set; }

        public virtual Customers IdNavigation { get; set; }
    }
}
