using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class PlayList
    {
        public PlayList()
        {
            Cluster = new HashSet<Cluster>();
        }

        public int ListId { get; set; }
        public DateTime DateList { get; set; }
        public int SystemId { get; set; }
        public bool Isupdate { get; set; }
        public int Playline { get; set; }
        public bool Islock { get; set; }
        public string TimeStart { get; set; }
        public int? MasterPlaylistId { get; set; }
        public int? ApproverId { get; set; }
        public DateTime TimeLast { get; set; }
        public int? Changed { get; set; }
        public int Cueline { get; set; }
        public int? UserId { get; set; }
        public DateTime? LastTime { get; set; }

        public virtual ICollection<Cluster> Cluster { get; set; }
    }
}
