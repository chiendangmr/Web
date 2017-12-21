using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Workflow
{
    [Table("WorkflowDiagramVersion", Schema = "Workflow")]
    public class DiagramVersion
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid WorkflowDiagramId { get; set; }

        [ForeignKey(nameof(WorkflowDiagramId))]
        public Diagram Diagram { get; set; }

        [ForeignKey(nameof(Entities.Workflow.Diagram.WorkflowDiagramVersionId))]
        public ICollection<Diagram> Diagrams { get; } = new HashSet<Diagram>();

        public string Data { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public bool Activated { get; set; }

        public Guid? UserId { get; set; }

        [ForeignKey(nameof(Workflow.WorkflowDiagramVersionId))]
        public ICollection<Workflow> Workflows { get; } = new HashSet<Workflow>();
    }
}
