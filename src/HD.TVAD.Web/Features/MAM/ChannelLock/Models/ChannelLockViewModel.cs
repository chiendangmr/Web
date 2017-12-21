using System;
using System.Collections.Generic;

namespace HD.TVAD.Web.Models
{
    public class ChannelLockViewModel
    {
        public Guid? Id { get; set; }
        public Guid? ContentId { get; set; }
        public Guid? ChannelId { get; set; }
        public string ChannelName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TimeBandBaseNoLockStr
        {
            get
            {
                var result = "";
                if (LstTimeBandBaseNoLockName != null)
                    foreach (var temp in LstTimeBandBaseNoLockName)
                    {
                        result += temp + ", ";
                    }
                return result == "" ? "" : result.Remove(result.Length - 2);
            }
        }

        public List<Guid> LstTimeBandBaseNoLockId { get; set; }
        public List<string> LstTimeBandBaseNoLockName { get; set; }
    }
}