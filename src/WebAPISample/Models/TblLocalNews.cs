using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblLocalNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public int? DeparmentId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public bool Enabled { get; set; }
        public string Content { get; set; }
        public int Category { get; set; }
        public DateTime? ExpiredPinnedDate { get; set; }
        public bool Pinned { get; set; }
    }
}
