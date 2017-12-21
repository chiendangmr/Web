using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Workflow
{
    [Table("ActivityRunning", Schema = "Workflow")]
    public class ActivityRunning
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid WorkflowId { get; set; }

        [ForeignKey(nameof(WorkflowId))]
        public Workflow Workflow { get; set; }

        public Guid ActivityId { get; set; }

        [ForeignKey(nameof(ActivityId))]
        public Activity Activity { get; set; }

        public Guid? ActivityRunningStateId { get; set; }

        [ForeignKey(nameof(ActivityRunningStateId))]
        public ActivityRunningState CurrentState { get; set; }

        [ForeignKey(nameof(ActivityRunningState.ActivityRunningId))]
        public ICollection<ActivityRunningState> States { get; } = new HashSet<ActivityRunningState>();
    }
}
