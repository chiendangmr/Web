using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblRepair
    {
        public int RepairId { get; set; }
        public string EquipmentId { get; set; }
        public string RepairCode { get; set; }
        public string RepairContent { get; set; }
        public string RepairCause { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? RepairExpense { get; set; }
        public string RepairPlace { get; set; }
    }
}
