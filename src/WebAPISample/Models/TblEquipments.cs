using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblEquipments
    {
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public int? DepartmentId { get; set; }
        public string EquipmentNumber { get; set; }
        public string EquipmentSpecs { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? RepairDate { get; set; }
        public decimal? Price { get; set; }
        public int? EquipmentStatusId { get; set; }
        public string BookingStatus { get; set; }
        public DateTime? StatusStartDate { get; set; }
        public DateTime? StatusEndDate { get; set; }
        public int? EquipmentCategoryId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string CurrentPosition { get; set; }
        public int? LastestUser { get; set; }
        public bool? Checked { get; set; }
    }
}
