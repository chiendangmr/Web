using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblNews
    {
        public long NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDuration { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpectedCompleteDate { get; set; }
        public string ContentSummary { get; set; }
        public long? CurrentContentId { get; set; }
        public int? ApproveStatusId { get; set; }
        public string ApproverComment { get; set; }
        public int? ApproverId { get; set; }
        public int? ReadingSpeed { get; set; }
        public int? IsLock { get; set; }
        public long? MediaId { get; set; }
        public int? CurrentCheckLevel { get; set; }
        public int? NewsTypeGroupId { get; set; }
        public int? NewsTypeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? NewsSourceId { get; set; }
        public int? IsOnAired { get; set; }
        public int? IsArchieved { get; set; }
        public string Notes { get; set; }
        public string Cgcontent { get; set; }
        public int? ResourceAllocatorStatus { get; set; }
        public string NewsPlace { get; set; }
        public bool? Checked { get; set; }
    }
}
