using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblVehicles
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string PlateNumber { get; set; }
        public DateTime? TestingDate { get; set; }
        public DateTime? TestingExpireDate { get; set; }
        public int? CurrentKm { get; set; }
        public int? DepartmentId { get; set; }
        public string Specs { get; set; }
        public int? SeatNumber { get; set; }
        public DateTime? BuyingDate { get; set; }
        public DateTime? ReparingDate { get; set; }
        public decimal? Price { get; set; }
        public int? VehicleTypeId { get; set; }
        public int? VehicleStatusId { get; set; }
        public DateTime? StatusStartDate { get; set; }
        public DateTime? StatusEndDate { get; set; }
        public bool? Checked { get; set; }
    }
}
