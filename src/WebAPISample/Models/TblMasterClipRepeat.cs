using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblMasterClipRepeat
    {
        public int Id { get; set; }
        public int MasterClipId { get; set; }
        public string StartTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RepeatWeeks { get; set; }
        public bool OnSunday { get; set; }
        public bool OnMonday { get; set; }
        public bool OnTuesday { get; set; }
        public bool OnWednesday { get; set; }
        public bool OnThursday { get; set; }
        public bool OnFriday { get; set; }
        public bool OnSaturday { get; set; }
        public bool EnableRerun { get; set; }
        public int? DefaultMasterClipStatusId { get; set; }
        public int SectorId { get; set; }
    }
}
