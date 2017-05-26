using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblNewsVotes
    {
        public long NewsId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int? VoteMark { get; set; }
        public long Id { get; set; }
    }
}
