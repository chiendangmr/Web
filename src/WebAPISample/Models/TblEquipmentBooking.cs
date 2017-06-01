using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblEquipmentBooking
    {
        public int BookingId { get; set; }
        public int? EquipId { get; set; }
        public int? BookingUserId { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? NewsId { get; set; }
        public int? ApproverId1 { get; set; }
        public string Approver1Comment { get; set; }
        public int? ApproverId2 { get; set; }
        public int? Approver2Comment { get; set; }
        public int? EquipBookingApproveStatusId { get; set; }
        public bool? IsInvisible { get; set; }
        public string Notes { get; set; }
    }
}
