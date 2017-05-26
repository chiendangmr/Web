using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblVehicleBooking
    {
        public int BookingId { get; set; }
        public int? VehicleId { get; set; }
        public int? BookingUserId { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ExpectKm { get; set; }
        public int? ApproverId1 { get; set; }
        public string Approver1Comment { get; set; }
        public int? ApproverId2 { get; set; }
        public string Approver2Comment { get; set; }
        public int? VehicleBookingApproveStatusId { get; set; }
        public bool? IsInvisible { get; set; }
        public string Notes { get; set; }
    }
}
