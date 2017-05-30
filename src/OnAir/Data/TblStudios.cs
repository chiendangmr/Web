using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblStudios
    {
        public int StudioId { get; set; }
        public string StudioName { get; set; }
        public int? DepartmentId { get; set; }
        public string StudioAddress { get; set; }
        public string StudioSize { get; set; }
        public int? NumberOfSeat { get; set; }
        public decimal? Price { get; set; }
        public int? StudioStatusId { get; set; }
        public DateTime? StartDateStatus { get; set; }
        public DateTime? EndDateStatus { get; set; }
        public bool? Checked { get; set; }
    }
}
