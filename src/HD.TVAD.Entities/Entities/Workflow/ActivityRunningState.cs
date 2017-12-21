using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Workflow
{
    [Table("ActivityRunningState", Schema = "Workflow")]
    public class ActivityRunningState
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ActivityRunningId { get; set; }

        [ForeignKey(nameof(ActivityRunningId))]
        public ActivityRunning ActivityRunning { get; set; }

        public Guid? UserId { get; set; }

        public ActivityRunningStateEnum State { get; set; }

        public string Name { get; set; }

        public string Reason { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [ForeignKey(nameof(Entities.Workflow.ActivityRunning.ActivityRunningStateId))]
        public ICollection<ActivityRunning> IsCurrentOfActivityRunnings { get; set; }
    }

    public enum ActivityRunningStateEnum : int
    {
        Pending = 1,
        Inprogress = 2,
        Successed = 3,
        Failure = 4,
    }
}
