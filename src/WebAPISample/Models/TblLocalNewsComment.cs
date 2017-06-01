using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblLocalNewsComment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LocalNewsId { get; set; }
        public string Content { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
