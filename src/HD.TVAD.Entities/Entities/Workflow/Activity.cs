using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Workflow
{
    [Table("Activity", Schema = "Workflow")]
    public class Activity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public Guid? ActivityProviderId { get; set; }

        [ForeignKey(nameof(ActivityProviderId))]
        public ActivityProvider Provider { get; set; }

        public string Parameter { get; set; }

        public string Description { get; set; }

        public string DesignData { get; set; }

        [ForeignKey(nameof(ActivityRunning.ActivityId))]
        public ICollection<ActivityRunning> ActivityRunnings { get; set; }
    }
}
