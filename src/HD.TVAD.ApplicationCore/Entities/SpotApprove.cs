using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class SpotApprove
    {
        public Guid Id { get; set; }
        public int Index { get; set; }

        public virtual SpotBooking IdNavigation { get; set; }
    }
}
