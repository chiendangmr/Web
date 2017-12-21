using System;

namespace HD.TVAD.Web.Models
{
    public class TimeBandBaseNoLockViewModel
    {
        public Guid? LockId { get; set; }
        public Guid? TimeBandBaseId { get; set; }       
        public string TimeBandBaseName { get; set; }
    }
}