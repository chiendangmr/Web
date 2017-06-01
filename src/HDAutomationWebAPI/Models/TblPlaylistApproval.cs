using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblPlaylistApproval
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlaylistId { get; set; }
        public DateTime? Date { get; set; }
        public string Note { get; set; }
    }
}
