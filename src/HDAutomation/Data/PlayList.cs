using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAutomation.Data
{
    public class PlayList
    {
        public int ListID { get; set; }
        public DateTime DateList { get; set; }
        public int SystenID { get; set; }
        public bool isupdate { get; set; }
        public int playline { get; set; }
        public bool islock { set; get; }
        public string TimeStart { get; set; }
        public int? MasterPlaylistId { get; set; }
        public int? approverID { get; set; }
        public DateTime TimeLast { get; set; }
        public int? Changed { get; set; }
        public int cueline { get; set; }
        public int? UserId { get; set; }
        public DateTime? LastTime { get; set; }
    }
}
