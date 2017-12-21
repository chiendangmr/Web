using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Workflow
{
    [Table("Workflow", Schema = "Workflow")]
    public class Workflow
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsMain { get; set; }

        public bool Disabled { get; set; }

        public Guid? WorkflowDiagramVersionId { get; set; }

        [ForeignKey(nameof(WorkflowDiagramVersionId))]
        public DiagramVersion DiagramVersion { get; set; }

        public Guid? ExternalId { get; set; }

        public int ExternalType { get; set; }

        public DateTimeOffset CreatedTime { get; set; }

        public string Data { get; set; }

        [ForeignKey(nameof(ActivityRunning.WorkflowId))]
        public ICollection<ActivityRunning> ActivityRunnings { get; } = new HashSet<ActivityRunning>();
    }
}
